
--CREATE procedure spGetDocSpecialities      
--as      
--begin      
--SELECT cd,dcd FROM cd_dcd a where a.typ = 28      
--and ISNULL(a.add_info_2,'0') = '1'  
--order by a.dcd        
--end     
    

    go

    update CD_DCD set Add_info_2 = 1 WHERE typ = 28 
    and cd in (1,2,3,4,5,6,7,8,10,11,19,21,34,49)

    
    update CD_DCD set Add_info_2 = 0 WHERE typ = 28 
    and cd not in (1,2,3,4,5,6,7,8,10,11,19,21,34,49)



    go



        
CREATE or alter procedure spGetDocSpecialities      
as      
begin      
--SELECT cd,dcd FROM cd_dcd a where a.typ = 28      
--and ISNULL(a.add_info_2,'0') = '1'  

-- #.SACHIN 20251126 : as per discussion with ravi kles only display specialities where units are found. 
SELECT cd,dcd FROM cd_dcd a where a.typ = 28      
and ISNULL(a.add_info_2,'0') = '1'  
and a.cd in (SELECT splty_cd from doc_mst x where x.ti_flg =  'T')

order by a.dcd        
end     
    


    go


        
CREATE or alter procedure spGetDocUnitsBySpecialityCd
(
@SpltyCd int
)
as      
begin      
SELECT doc_cd UnitCd,isnull(a.doc_lst_nm,'') + ' ' + isnull(a.doc_frst_nm ,'') 
+ ' ' +  isnull(a.doc_mid_nm ,'') + ' '    UnitName 
FROM doc_mst a where a.splty_cd = @SpltyCd       
and isnull(a.ti_flg,'') = 'T'
order by 2
end     
    

    go



              
alter procedure [dbo].[SpInsPtnQuickReg]            
(            
@PatientNo bigint ,            
@FullName varchar(500),            
@FatherName varchar(500),            
@Age int,            
@Sex varchar(1),            
@DocSpltyCd int ,            
@MobileNo varchar(20),            
@patientSourceCode int,    
@PatientAddressLine1 varchar(150) ='',    
@PatientAddressLine2 varchar(150) ='',    
@PatientAddressLine3 varchar(150) ='',    
@DocUnitCd int    =0
)            
as            
/*            
Author : Sachin Manugade            
Date   :08 Feb 2024            
Remarks : written to insert record into patient master index with minimum fields.            
*/            
begin             
 declare @crtDt date  = getdate();            
 declare @crtTm time = getdate();            
            
 declare @dateofBirth date = DATEADD(year, - @age, getdate())            
           
 declare @defaultStateCd int = (SELECT StateCd  FROM StateMaster a where a.IsBaseState = 1 );          
 SET @defaultStateCd = isnull(@defaultStateCd,0);          
          
 declare @defaultCountryCd int = (SELECT CountryCd  FROM CountryMaster  a where a.IsBaseCountry = 1 );          
 SET @defaultCountryCd = isnull(@defaultCountryCd,0);          
          
  declare @sms_MSG as varchar(100) -- Prakash sms format          
   declare @dt date =getdate()   --Prakash sms datetime          
          
 exec [SpInsPtnMst1001]             
 @ptn_no=@PatientNo,            
 @typ_flg=N'P',            
 @ttl_cd=1,            
 @ptn_lst_nm= @FullName,            
 @ptn_frst_nm=@FatherName ,@ptn_mid_nm='.',            
 @sex=@Sex,            
 @brth_dt= @dateofBirth  ,            
 @age_yy=@Age,            
 @age_mm=0,            
 @age_dd=0,            
 @prmnt_city=1279105,            
 @prmnt_tel=@MobileNo,            
 @prmnt_cntry=@defaultCountryCd,            
 @ntnlty_cd=1,            
 @doc_cd=0,            
 @exp_dt='01 JAN 2099',            
 @crt_dt=@crtDt ,            
 @crt_tm=@crtTm ,            
 @crt_usr_id=N'WEBPORTAL',            
 @updt_dt=@crtDt,            
 @updt_tm=@crtTm,            
 @updt_usr_id=N'WEBPORTAL',            
 @clnc_cd=0,            
 @statecd=@defaultStateCd,          
 @bill_type=1,            
 @no=0,          
 @pIsPtnBlackListed=0,            
 @pISEmergencyPtn=0,            
 @istranblocked=0,          
 @ptnsrccd =@patientSourceCode ,    
 @prmnt_addrs1 = @PatientAddressLine1,     
 @prmnt_addrs2 = @PatientAddressLine2 ,    
 @prmnt_addrs3 = @PatientAddressLine3    
 , @pDocSpltyCd = @DocSpltyCd           
 ;            
            
IF @@ROWCOUNT > 0             
BEGIN             
exec [SP2]             
 @ptn_no=@PatientNo,            
 @crt_dt=@crtDt,            
 @crt_tm=@crttm,            
 @crt_usr_id=N'WEBPORTAL',            
 @updt_dt=@crtDt,            
 @updt_tm=@crtTm,            
 @updt_usr_id=N'WEBPORTAL';            
            
END             
  ---Prkash added SMS for regstration --15022024          
           
     --       {#var#} - Your registered patient number is {#var#} KLES Hospital        
  set  @sms_MSG =@FullName +' - Your registered patient number is '+convert(Varchar(10),@PatientNo)+' KLES Hospital'           
            
  exec  sp_Add_Sms_Dtl       1 ,220,@MobileNo,@sms_MSG , @dt,1,@PatientNo ,0,'WEBPORTAL',0          
  
  -- call procedure to insert data into OP_PTN_VST        
  exec spInsertOpPtnVstCampReg  @ptn_no = @PatientNo , @doc_splty_cd =@DocSpltyCd , @doc_cd   =@DocUnitCd;
  
end 

 

go



CREATE OR ALTER PROCEDURE dbo.spInsertOpPtnVstCampReg 
(
@ptn_no            BIGINT      = 0,
@doc_splty_cd int ,
 @doc_cd            INT         = 0
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRAN;

    BEGIN TRY
        -----------------------------------------------------
        -- Declare variables for every column (with defaults)
        -----------------------------------------------------
        DECLARE
            @clnc_cd           INT         = 1,               -- clinic code (pick appropriate default)
            @vst_no            INT         = NULL,            -- will compute next
            
            @espd_no           INT         = 0,
           
            @cse_typ_cd        INT         = 0,
            @ptn_cls_cd        INT         = 17, --17 = OPD - Hospital
            @free_flg          VARCHAR(1)  = 'C',
            @emp_no            VARCHAR(10) = NULL,
            @ar_cd             INT         = 0,
            @co_refnc_no       VARCHAR(30) = '',
            @new_old_flg       VARCHAR(1)  = 'N',
            @vst_type          INT         = 1,
            @rev_dt            DATETIME    = NULL,
            @Billed            BIT         = 0,
            @paid_dttm         DATETIME    = NULL,
            @Chrg_Code         INT         = 1001,
            @Test_Code         INT         = 1001101, -- New Visit  -  Consultation
            @Appt_No           INT         = 0,
            @Fct_Code          INT         = 0,
            @sch_vst_dt        DATETIME    = NULL,
            @sch_vst_From_tm   DATETIME    = NULL,
            @sch_vst_To_tm     DATETIME    = NULL,
            @vst_flg           CHAR(1)     = 9,
            @act_vst_dttm      DATETIME    = NULL,
            @act_doc_cd        INT         = 0,
            @act_clnc_cd       INT         = 0,
            @acknowledge_tm    DATETIME    = NULL,
            @vstCompleted_tm   DATETIME    = NULL,
            @crt_dttm          DATETIME    = GETDATE(),
            @crt_usr_id        VARCHAR(16) = 'WEBPORTAL',
            @uptd_trn_cd       INT         = 0,
            @updt_dttm         DATETIME    = getdate(),
            @updt_usr_id       VARCHAR(16) = 'WEBPORTAL',
            @no                INT         = 0,
            @visit_typ         CHAR(1)     = 'N',
            @token_no          VARCHAR(15) = NULL,
            @IsCancelled       BIT         = 0,
            @CancelledVchNo    INT         = NULL,
            @ReportedDtTm      DATETIME    = NULL,
            @ReportedUsrID     VARCHAR(16) = NULL,
            @DocCallDtTm       DATETIME    = NULL,
            @DocCallByUsrID    VARCHAR(16) = NULL,
            @VisitClosedDtTm   DATETIME    = NULL,
            @VisitClosedByUsrID VARCHAR(16) = NULL,
            @VisitStatusCd     TINYINT     = 1,
            @RoomNo            VARCHAR(6)  = NULL,
            @PtnVisitDay       INT         = 0,
            @EdRegNo           BIGINT      = 0,
            @token_alpha       VARCHAR(3)  = '',
            @ReferralNo        BIGINT      = 0,
            @ConsultDocCd      INT         = NULL,
          
            @Ref_Doc_Splty_Cd  INT         = 0,
            @Doc_Team_Cd       INT         = 0,
            @Ref_Doc_Team_Cd   INT         = 0;


          --- DEFAULT VALUES   
          SELECT @rev_dt = rev_dt from hsp_in_dt; 
          SET   @act_doc_cd                  = @doc_cd;
          SET   @act_clnc_cd                 = @clnc_cd;
           SET @Doc_Team_Cd       = @doc_cd;

        -----------------------------------------------------
        -- Compute next vst_no for the clinic to avoid PK clash
        -- If table empty for this clinic, starts from 1
        -----------------------------------------------------
        SELECT @vst_no = ISNULL(a.vst_no, 1) 
        FROM clnc_mst a
        WHERE clnc_cd = @clnc_cd;

        -- update next clinic visit no 
        UPDATE clnc_mst 
        SET vst_no =  ISNULL(vst_no, 1) +1
        WHERE clnc_cd = @clnc_cd;


        -----------------------------------------------------
        -- Final insert
        -----------------------------------------------------
        INSERT INTO dbo.op_ptn_vst
        (
            clnc_cd, vst_no, ptn_no, espd_no, doc_cd, cse_typ_cd, ptn_cls_cd,
            free_flg, emp_no, ar_cd, co_refnc_no, new_old_flg, vst_type, rev_dt,
            Billed, paid_dttm, Chrg_Code, Test_Code, Appt_No, Fct_Code,
            sch_vst_dt, sch_vst_From_tm, sch_vst_To_tm, vst_flg, act_vst_dttm,
            act_doc_cd, act_clnc_cd, acknowledge_tm, vstCompleted_tm,
            crt_dttm, crt_usr_id, uptd_trn_cd, updt_dttm, updt_usr_id,
            no, visit_typ, token_no, IsCancelled, CancelledVchNo,
            ReportedDtTm, ReportedUsrID, DocCallDtTm, DocCallByUsrID,
            VisitClosedDtTm, VisitClosedByUsrID, VisitStatusCd, RoomNo,
            PtnVisitDay, EdRegNo, token_alpha, ReferralNo, ConsultDocCd,
            Doc_Splty_Cd, Ref_Doc_Splty_Cd, Doc_Team_Cd, Ref_Doc_Team_Cd
        )
        VALUES
        (
            @clnc_cd, @vst_no, @ptn_no, @espd_no, @doc_cd, @cse_typ_cd, @ptn_cls_cd,
            @free_flg, @emp_no, @ar_cd, @co_refnc_no, @new_old_flg, @vst_type, @rev_dt,
            @Billed, @paid_dttm, @Chrg_Code, @Test_Code, @Appt_No, @Fct_Code,
            @sch_vst_dt, @sch_vst_From_tm, @sch_vst_To_tm, @vst_flg, @act_vst_dttm,
            @act_doc_cd, @act_clnc_cd, @acknowledge_tm, @vstCompleted_tm,
            @crt_dttm, @crt_usr_id, @uptd_trn_cd, @updt_dttm, @updt_usr_id,
            @no, @visit_typ, @token_no, @IsCancelled, @CancelledVchNo,
            @ReportedDtTm, @ReportedUsrID, @DocCallDtTm, @DocCallByUsrID,
            @VisitClosedDtTm, @VisitClosedByUsrID, @VisitStatusCd, @RoomNo,
            @PtnVisitDay, @EdRegNo, @token_alpha, @ReferralNo, @ConsultDocCd,
            @Doc_Splty_Cd, @Ref_Doc_Splty_Cd, @Doc_Team_Cd, @Ref_Doc_Team_Cd
        );

        COMMIT TRAN;

        -- Optionally return inserted keys / values
        SELECT @clnc_cd AS clnc_cd, @vst_no AS vst_no;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0
            ROLLBACK TRAN;

        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrNo INT = ERROR_NUMBER();
        RAISERROR('spInsertOpPtnVst_NoParams failed. Error %d: %s', 16, 1, @ErrNo, @ErrMsg);
        RETURN;
    END CATCH
END;
GO
