using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace iConnect
{

    public class AWSClass
    {
        public static AmazonDynamoDBClient dbClient = null;
        public static CognitoAWSCredentials credentials = null;
        public static DynamoDBContext context = null;

        public AWSClass()
        {
            FormConnection();
            AWSFunction();
        }

        void FormConnection()
        {

             credentials = new CognitoAWSCredentials(
                                  "us-east-1:9230d735-e226-4d9b-8120-be8e40f04fee", // Identity Pool ID, 
                                  RegionEndpoint.USEast1);

             dbClient = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);

            //client = new AmazonDynamoDBClient("AKIAJIHWZPTJHJFGDHKA", "TC2O0LC2imFnQJ2S6qxar78SkAH1Foe5gD4Mg6VD", RegionEndpoint.USEast1);
            context = new DynamoDBContext(dbClient);
        }



        void AWSFunction()
        {
           
            if (!dbClient.ListTablesAsync().Result.TableNames.Contains("iConnectTable"))
            {
                dbClient.CreateTableAsync(new CreateTableRequest
                {
                    TableName = "iConnectTable",
                    ProvisionedThroughput = new ProvisionedThroughput { ReadCapacityUnits = 10, WriteCapacityUnits = 10 },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Name",
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = "Name", AttributeType = ScalarAttributeType.S }
                    }
                });

            }
            else
            {
                iConnectTable iConnectTableObject = new iConnectTable
                {
                    Name = "ShubhamGoel",
                    Message = "This is my messgae",
                    Date = new DateTime(2017, 9, 10),
                    EventName = "bcghfghjk"
                };
                context.SaveAsync<iConnectTable>(iConnectTableObject);
            }


        }
    }

	[DynamoDBTable("iConnectTable")]
	public class iConnectTable
	{
		[DynamoDBHashKey]
		public string Name { get; set; }

		public string Message { get; set; }

		public DateTime Date { get; set; }

		[DynamoDBProperty(AttributeName = "Event")]
		public string EventName { get; set; }

		//[DynamoDBProperty(Converter = typeof(AddressConverter))]
		//public Address Address { get; set; }

		//[DynamoDBIgnore]
		//public string Comment { get; set; }

	}

}
