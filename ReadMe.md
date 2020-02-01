* link: https://www.c-sharpcorner.com/blogs/jwt-based-tokenisation-via-net-core
* The project has done by 03/01/2010 (DD/MM/YYYY)
* GetAccessToken: https://localhost:5001/api/auth/login (method: POST, data: {     "UserName":"chien",     "Password": "abc@123"  }  )
* Test API: https://localhost:5001/weatherforecast (method: GET, data: beartoken from "GetAccessToken" )