@echo off
rem Apache License Header (unchanged)

IF [%1] EQU [] (
	echo USAGE: %0 server.properties
	EXIT /B 1
)

SetLocal
IF ["%KAFKA_LOG4J_OPTS%"] EQU [""] (
    set KAFKA_LOG4J_OPTS=-Dlog4j2.configurationFile=%~dp0../../config/log4j2.yaml
)

rem ❌ Removed wmic check — just set 64-bit heap directly
IF ["%KAFKA_HEAP_OPTS%"] EQU [""] (
    set KAFKA_HEAP_OPTS=-Xmx1G -Xms1G
)

"%~dp0kafka-run-class.bat" kafka.Kafka %*
EndLocal