# Cloud Storage Web Application with FaceRecognition as 2F Auth

Cloud is a cloud storage system where you can store data and share it to any user connected to it.
You can also have 2 factor authentication to protect your data by face recognition.
This project was built in Microsoft Visual Studio Code by using c#(asp.net) and javascript




#### Demo

[![image](https://user-images.githubusercontent.com/69571769/173809833-7d8b778d-f048-4461-88cd-0a2215b22bd6.png)](https://drive.google.com/file/d/1m4VjrXCdJOOXuZban1Ac--veb3FO0f3m/view?usp=sharing)





#### Making Scloud Highly Available

Project deployment was through Azure, I deployed the webserver on 2 Vms having a common disk shared via a failover cluster using Azure AD DS, on top of that both of the Vms are in a Availability Set, so while explaining this project to others i explained all these concepts such as:

For this we tuned the Infrastucture a little bit, so Infrastructure and Features/Configs are:  

a)Solution will be hosted on 2 Machines.  
b)Vms be connected to a Load Balancer.  
c)Will use Remote SQL Server.  
d)Vms will use a Shared Disk.  
e)Azure Active Directory Domain Services (Vms joined to Custom Domain taken from Name.com)  
f)Vms will be configured as a failover cluster.  
g)Vms will be placed in an Availability Set.  


#### Demo of Infrastructure Build


[![image](https://user-images.githubusercontent.com/69571769/173812937-6cc2b6c6-ed17-44f1-a78b-4112febd6297.png)](https://drive.google.com/file/d/1fnlps8zo9GIjFEQxo26_U6Pi7w2vI1cV/view?usp=sharing)



_______________________________________________________________________________________________________________________________________________________________________
#### LICENSE

Code and Media are under the respective Licenses:  
* [MIT](https://opensource.org/licenses/MIT)  
* [Creative Commons Zero v1.0 Universal](https://creativecommons.org/publicdomain/zero/1.0/)  

