Kafka Chat App - Java + Kafka 4.0.0

1. Make sure Kafka 4.0.0 is installed and extracted in kafka_2.13-4.0.0 folder.
2. Run kafka-storage.bat format -t <uuid> -c config\kraft\server.properties
3. Run kafka-server-start.bat -c config\kraft\server.properties
4. Double-click run_consumer.bat to start the chat receiver.
5. Double-click run_producer.bat to start sending messages.