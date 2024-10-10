Environment variable required: GOOGLE_MAP_API_KEY

On local machine, you can set it in .env file (Where Program.cs file is located)
.env file content:
```
GOOGLE_MAP_API_KEY='Your_Key_Here'
```

On Azure, you can set it in Application Settings
Follow to https://portal.azure.com/ -> Your App Service -> Settings -> Environment Variables 
Add new variable with name GOOGLE_MAP_API_KEY and value as your key.
```