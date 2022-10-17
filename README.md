# Cloud Storage Web Application with FaceRecognition as 2F Auth

SCloud is a cloud storage system where you can store data and share it to any user connected to it.  
You can also have 2 factor authentication to protect your data by face recognition.  
This project was built in Microsoft Visual Studio Code by using C#(ASP.NET), Javascript and Python(Face Recognition).   


## Making SCloud work on your Device (Pre-Reqs):  
* Installations:  
>1. Visual Studio 2019 Community   
>2. Python 3.7x or above  
>3. Windows IIS 10 (I haven't tried this on linux but there must be some way to host it on linux too).  

* Extensions: (Optional as the folder named packages already has it)
> ASP.NET AJAX Extenstion (NuGET Package)

* Service Email ID:  
>1. Create a gmail account.
>2. Open SignUp.aspx.cs and put its email and application password instead of "SERVICE_EMAIL", "PASSWORD" 
>3. You need to enable 2f auth on it and create an application password add that to the code as password.  

* Database:  
>1. Put your MSC SQL Server database credentials wherever you find ```Server=YOUR_SERVER_IP;uid=USER_ID;pwd=PASSWORD;database=DB_NAME``` use project search to find and replace all.  
>2. The SQL Query below is used to create a table on MSC SQL Server Database where SCloud will store it's user's data.    

```
create table cloudlogin(
  username varchar(100) not null unique,
  password varchar(100) not null unique,
  email varchar(100) not null unique,
  secretkey varchar(25) not null unique
)
```
```
create table Cloudlogin_2FactorAuth(
  username varchar(100) not null unique,
  status_2f varchar(25) not null
)
```
__Once the above is done then SCloud must be hosted using Windows IIS 10 and things must work :crossed_fingers:__

## Demo

[![image](https://user-images.githubusercontent.com/69571769/173809833-7d8b778d-f048-4461-88cd-0a2215b22bd6.png)](https://youtu.be/fPlXFuMpMks)





#### Making Scloud Highly Available

Project deployment was through Azure, I deployed the webserver on 2 Vms having a common disk shared via a failover cluster using Azure AD DS, on top of that both of the Vms are in a Availability Set.

For this we tuned the Infrastucture a little bit, so Infrastructure and Features/Configs are:  

>a)Solution will be hosted on 2 Machines.  
b)Vms be connected to a Load Balancer.  
c)Will use Remote SQL Server.  
d)Vms will use a Shared Disk.  
e)Azure Active Directory Domain Services (Vms joined to Custom Domain taken from Name.com)  
f)Vms will be configured as a failover cluster.  
g)Vms will be placed in an Availability Set.  
  
    
![image](https://user-images.githubusercontent.com/69571769/181298281-f135ba00-a3cd-479c-bf8a-85c71ae9f8a5.png)



## Demo of Infrastructure Build


[![image](https://user-images.githubusercontent.com/69571769/173812937-6cc2b6c6-ed17-44f1-a78b-4112febd6297.png)](https://drive.google.com/file/d/1fnlps8zo9GIjFEQxo26_U6Pi7w2vI1cV/view?usp=sharing)





