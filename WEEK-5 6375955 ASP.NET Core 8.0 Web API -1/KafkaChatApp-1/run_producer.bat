@echo off
set CLASSPATH=.;kafka_2.13-4.0.0\libs\*
java -cp "%CLASSPATH%" ChatProducer
pause