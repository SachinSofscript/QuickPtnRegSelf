USE [SOFCWHMIS]
GO
/****** Object:  StoredProcedure [dbo].[SpInsPtnQuickReg]    Script Date: 09/02/2026 4:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
ALTER procedure [dbo].[SpInsPtnQuickRegSelf]        
(        
@PatientNo bigint ,        
@FullName varchar(500),        
@FatherName varchar(500),        
@Age int,        
@Sex varchar(1),        
@DocSpltyCd int ,        
@MobileNo varchar(20),        
@patientSourceCode int,
@PatientAddressLine1 varchar(150),
@PatientAddressLine2 varchar(150),
@PatientAddressLine3 varchar(150)
,    
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
 @crt_usr_id=N'WEBPORTALSelf',        
 @updt_dt=@crtDt,        
 @updt_tm=@crtTm,        
 @updt_usr_id=N'WEBPORTALSelf',        
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
 , @pDocSpltyCd = @DocSpltyCd,
 @Mobile = @MobileNo,
 @pmobile2 = @MobileNo 
 ;        
        
IF @@ROWCOUNT > 0         
BEGIN         
exec [SP2]         
 @ptn_no=@PatientNo,        
 @crt_dt=@crtDt,        
 @crt_tm=@crttm,        
 @crt_usr_id=N'WEBPORTALSelf',        
 @updt_dt=@crtDt,        
 @updt_tm=@crtTm,        
 @updt_usr_id=N'WEBPORTALSelf';        
        
END         
  ---Prkash added SMS for regstration --15022024      
       
     --       {#var#} - Your registered patient number is {#var#} KLES Hospital    
  set  @sms_MSG =@FullName +' - Your registered patient number is '+convert(Varchar(10),@PatientNo)+' KLES Hospital'       
        
  exec  sp_Add_Sms_Dtl       1 ,220,@MobileNo,@sms_MSG , @dt,1,@PatientNo ,0,'WEBPORTALSelf',0      
      
 
  -- call procedure to insert data into OP_PTN_VST        
  ---exec spInsertOpPtnVstCampReg  @ptn_no = @PatientNo , @doc_splty_cd =@DocSpltyCd , @doc_cd   =@DocUnitCd;
  
end 