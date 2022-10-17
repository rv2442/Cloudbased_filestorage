Hi,
>A step by step guide to this project is not created as of now but, the Readme.md has links to many resources, the first video explains working logic, the pic after explains the infrastructure usingg azure and the next vid has reference to 2 vids using which I created that project on azure.


### Pre-Reqs:
>The SQL Query below is used to create a table on MSC SQL Server Database where SCloud will store it's user's data.    

```
create table cloudlogin(
  username varchar(100) not null unique,
  password varchar(100) not null unique,
  email varchar(100) not null unique,
  secretkey varchar(25) not null unique
)
```
