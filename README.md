### Welcome to the Final Project for Contemporary Programming!

This was created by Jason Welsh, William Pinson, and Nirupama Poojari

### How to develop in the project


First, clone down the project listed here 

```bash
git clone git@github.com:urboi11/FinalProject1.git
```
Once done, please make sure that the latest changes are present, then apply your changes

### Pushing changes to the repository

After all of your tests have been completed, make sure that the **Migrations** folder has been updated with any related database information if that is a change you made. This can be done by doing the following.


#### If you do not already have dotnet-ef - run this command.
```bash
dotnet tool install --global dotnet-ef
```
#### Updating the migrations folder 
```bash
dotnet ef migrations add {Name that you want}
```
After that command runs and is successful, commit your changes to your branch and then open a Pull Request to master.

Once merged, Two Github Action Pipelines will run and do the following <br>
1. The **WebAppDeploy.yml** in the .github/workflows directory will deploy the web app.
2. The **SqlDeploy.yml** in the .github/workflows directory will push new migrations to the SQL Database in Azure via SQLScript.


### Viewing the finished product
To view changes made to this project, you can by viewing the following URL.
[Web API](https://contemporarywebapi-agceb0ebf4ebe0c5.canadacentral-01.azurewebsites.net/swagger/index.html)
Please reach out to ask any questions, thanks again for viewing/contributing!
