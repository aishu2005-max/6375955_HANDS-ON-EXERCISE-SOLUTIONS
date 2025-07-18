@echo off
REM Set classpath to include all jars in the Kafka libs folder
set CLASSPATH=.;kafka_2.13-4.0.0\libs\*

echo [INFO] Compiling Java files...
javac -cp "%CLASSPATH%" -d src src\ChatProducer.java src\ChatConsumer.java

IF %ERRORLEVEL% EQU 0 (
    echo [SUCCESS] Compilation completed.
) ELSE (
    echo [ERROR] Compilation failed.
)
pause