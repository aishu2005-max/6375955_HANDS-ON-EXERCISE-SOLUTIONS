import org.apache.kafka.clients.producer.*;
import java.util.Properties;
import java.util.Scanner;

public class ChatProducer {
    public static void main(String[] args) {
        String topic = "chat-topic";

        Properties props = new Properties();
        props.put("bootstrap.servers", "localhost:9092");
        props.put("acks", "all");
        props.put("key.serializer", "org.apache.kafka.common.serialization.StringSerializer");
        props.put("value.serializer", "org.apache.kafka.common.serialization.StringSerializer");

        KafkaProducer<String, String> producer = new KafkaProducer<>(props);

        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter your name:");
        String username = scanner.nextLine();

        System.out.println("You can start typing messages. Type 'exit' to quit.");

        while (true) {
            String message = scanner.nextLine();
            if (message.equalsIgnoreCase("exit")) break;

            ProducerRecord<String, String> record = new ProducerRecord<>(topic, username, message);
            producer.send(record);
        }

        producer.close();
        scanner.close();
    }
}