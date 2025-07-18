@echo off
cd /d "C:\Users\hp\OneDrive\Desktop\WEEK-5~1.0WE\KAFKAC~1\KAFKAC~1\KAFKA_~1.0"
echo Creating topic chat_topic...
bin\windows\kafka-topics.bat --create --topic chat_topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1
echo ErrorLevel: %errorlevel%
pause
