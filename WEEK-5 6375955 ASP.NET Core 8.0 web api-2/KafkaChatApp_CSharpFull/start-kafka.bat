@echo off
cd /d "C:\Users\hp\OneDrive\Desktop\WEEK-5 6375955 ASP.NET Core 8.0 Web API\KafkaChatApp_CSharpFull\KafkaChatApp\kafka_2.13-4.0.0"
echo Starting Kafka broker...
bin\windows\kafka-server-start.bat config\kraft\server.properties
echo ErrorLevel: %errorlevel%
pause
