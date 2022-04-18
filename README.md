KafkaMicroService

1-docker-compose -f docker-compose-sqlserver.yaml up<br />
2-Ef-migration<br />
3-SQL<br />
<code>
use TelosCaseDb
go
exec sys.sp_cdc_enable_table 
@source_schema = N'dbo', 
@source_name = N'SellEntity', 
@role_name = NULL, 
@filegroup_name = N'', 
@supports_net_changes = 0 
</code><br />
4-buy-sqlserver.json<br />

<code>
{
    "name": "inventory-connector", 
    "config": {
        "connector.class": "io.debezium.connector.sqlserver.SqlServerConnector", 
        "database.hostname": "sqlserver", 
        "database.port": "1433", 
        "database.user": "sa", 
        "database.password": "1q2w3e4r!^+", 
        "database.dbname": "TelosCaseDb", 
        "database.server.name": "exampleserver", 
        "table.include.list": "dbo.buyEntities", 
        "database.history.kafka.bootstrap.servers": "kafka:9092", 
        "database.history.kafka.topic": "dbhistory.fullfillment" 
    }
}
</code><br />

<code>curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" http://localhost:8083/connectors/ -d @buy-sqlserver.json</code><br />


<code>docker-compose -f docker-compose-sqlserver.yaml exec kafka /kafka/bin/kafka-console-consumer.sh --bootstrap-server kafka:9092 --from-beginning --property print.key=true --topic exampleserver.dbo.buyEntities</code><br />
