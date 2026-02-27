# Datewise Changes – Feature Reference

## 2025-02-27

### Captcha improvements

- **Captcha image size**
  - Increased captcha image dimensions in `wwwroot/css/site.css`:
    - Image: **260px × 80px** (was height 50px only); added `object-fit: contain`.
    - Container width: **280px** (was 200px).
    - Input width: **220px** (was 180px).
- **Refresh captcha**
  - Implemented refresh logic in `Pages/Register.cshtml` (scripts section):
    - Click on “Change Captcha” prevents default and reloads the captcha image via cache-busting query parameter.
    - Clears `#DNTCaptchaInputText` on refresh.
    - Uses delegated click handler so it works after form reset or re-render.

---

*Add new entries at the top under the date (YYYY-MM-DD).*
