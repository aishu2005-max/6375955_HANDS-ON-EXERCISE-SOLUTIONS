@echo off
setlocal EnableDelayedExpansion

:: Change directory to Kafka installation
cd /d "%~dp0kafka_2.13-4.0.0"

:: Build CLASSPATH with all Kafka JARs
set CLASSPATH=
for %%f in (libs\*.jar) do (
    set CLASSPATH=!CLASSPATH!;libs\%%f
)

:: Use delayed expansion so it works correctly
setlocal enabledelayedexpansion

:: Start Kafka broker
java -cp "!CLASSPATH!" kafka.Kafka config\kraft\server.properties

endlocal
pause