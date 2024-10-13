For local development run this projct in HTPP mode. Api project should be run in HTTP mode too.
On Azure this projects will run in HTTPS mode.

Environment variable required: GOOGLE_MAP_API_KEY

For local development, you can set it in ..\Api\local.setting.json file. (Read the Api - ReadMe.md for details)

On Azure, you can set it in Application Settings
Follow to https://portal.azure.com/ -> Static Web Apps -> Your App Service -> Settings -> Environment Variables 
Add new variable with name GOOGLE_MAP_API_KEY and value as your key.

Development environment: 
Before running the application, make sure you have run Api project. By default, it runs on port 7071.
For run Api project read the ReadMe.md file in the Api project. 
Run "func start" in command prompt in the Api project directory.
