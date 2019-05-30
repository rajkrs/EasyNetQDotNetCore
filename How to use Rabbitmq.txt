Run RabbitMq through docker:
	docker run -d --hostname my-rabbit --name some-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management

Then go to:
http://localhost:15672

Credentials:
Username:guest
Password:guest


