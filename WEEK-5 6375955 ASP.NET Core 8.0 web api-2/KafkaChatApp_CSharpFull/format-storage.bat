@echo off
cd /d "C:\Users\hp\OneDrive\Desktop\WEEK-5 6375955 ASP.NET Core 8.0 Web API\KafkaChatApp_CSharpFull\KafkaChatApp\kafka_2.13-4.0.0"
echo Formatting Kafka storage...
bin\windows\kafka-storage.bat format -t a43dc055-c571-48fa-b38a-170fb4cc4ccd -c config\kraft\server.properties
echo ErrorLevel: %errorlevel%
pause
