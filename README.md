## AWS Sample App

Sample App using:
- ElasticBeanStalk , c# .net core 2.2 
- ElasticCache, redis

Quick vague instructions :) 
1. Git clone the repo
2. Install .net core 2.2 SDK
3. Create ElasticCache - redis cluster
    a. Edit code to use this cluster's endpoint.
4. Load in configuration 'micro-lb' 
    a. Create any configuration, and save it.  Then go into S3 and copy/paste this template and replace everything in the existing configuration file.
5. Create/verify security group on elasticcache that it's TCP port 6379 is open for the beanstalk's security group.
6. Create & Upload deployment zip
7. To tear down, delete the inbound rule created in #5, and then terminate the EB environment & cache cluster.

## /scripts 

`micro-lb` is a saved configuration of the elasticbeanstalk environment. Could recreate the environment for elasticbeanstalk via this one file.  The seperate infra dependencies outside of elasticbeanstalk are NOT in this configuration though.

`createBundle.sh` creates the deployment archive to give to elasticbeanstalk

`run.sh` runs the webapi local on your machine.


## Resources

* https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/dotnet-core-tutorial.html#dotnet-core-tutorial-generate

* https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/accessing-elasticache.html#grant-access
