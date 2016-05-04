# Storage-library
Helper to storage data for Universal Windows Platform

Date: 04/05/2016

* How to use:

To use the method "save" only need to pass as a parameter file name and the text you want to save. 
You have to call:
  
  await Storage.Save("file.json", string_info);

To retrieve the information we have saved just we have to tell method where the file has been saved. 
Call to:
  
  await Storage.Load("file.json");
