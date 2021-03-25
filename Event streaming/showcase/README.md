# Application monitoring with ProconTEL Event Streaming 

## Introduction

In short, this document will show how to use _ProconTEL Event Streaming_ and consume published events, store data in [PostgreSQL](https://www.postgresql.org/) and later use [Grafana](https://grafana.com/) to visualize gather information. _PostgreSQL_ and _Grafana_ are used here only as an example, however it is possible to utilitize data by any other tool like _ELK_, _Prometheus_, etc.

Technologies which you should be familiar with, which are used in this showcase, include: [.NET5](https://docs.microsoft.com/en-us/dotnet/core/dotnet-five), [docker](https://www.docker.com/), [PostgreSQL](https://www.postgresql.org/) and [Grafana](https://grafana.com/).

If you're interested only in .NET connector to _ProconTEL Event Streaming_ jump directly to section [.NET Connector](#dotnet-connector).


## Running PostgreSQL

If you don't have _PostgreSQL_ database running then run _docker_ for Linux contianers, open your favourite terminal and type following commands in order to download and run latest version of _PostgreSQL_ database:

```shell
docker pull postgres
docker run -d --name postgres-db -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres
```

Database engine will be listenig at port 5432 and you can login as user `postgres` with the same password. If you have any client, please use it to connect with database, otherwise check the [Running pgadmin](#running-pgadmin) section below. 

Next, connect to database and execute following script:

```sql
CREATE TABLE public.metrics
(
    "Id" bigint NOT NULL DEFAULT nextval('"metrics_Id_seq"'::regclass),
    "DataV" jsonb,
    "TimeV" timestamp(6) without time zone NOT NULL,
    CONSTRAINT metrics_pkey PRIMARY KEY ("Id")
)

TABLESPACE pg_default;
```


<div id='running-pgadmin'/>

### Running pgadmin

Execute following commands to download and start PostgreSQL client application _pgadmin_:

```shell
docker pull dpage/pgadmin4
docker run -p 8080:80 -e 'PGADMIN_DEFAULT_EMAIL=root@m.pl' -e 'PGADMIN_DEFAULT_PASSWORD=pgadmin' -d dpage/pgadmin4
```

Open `localhost:8080` and login as user `root@m.pl` with password `pgadmin`. Next set up connection to _PostgreSQL_ database. If you are running database on docker, use the WSL IP address. For example, use IP `172.24.224.1` as _PostgreSQL_ database server, in case of following output from `ipconfig`:

```shell
PS C:\> ipconfig

...

Ethernet adapter vEthernet (WSL):

  Connection-specific DNS Suffix  . :
  Link-local IPv6 Address . . . . . : fe80::7d08:cc48:974e:d2a8%53
  IPv4 Address. . . . . . . . . . . : 172.24.224.1
  Subnet Mask . . . . . . . . . . . : 255.255.240.0
  Default Gateway . . . . . . . . . :
```

## Running Grafana

Run _docker_ for Linux contianers, open your favourite terminal and type following commands in order to download and run latest version of _Grafana_:

```shell
docker run -d -p 3000:3000 --name grafana grafana/grafana
```

Open `localhost:3000` and login as user `admin` and with the same phrase for password. Next you will be asked to select a new password. 

Add a new datasource and select as a source _PostgreSQL_ database. Type server address, port, user name and password and click `Save & Test`. 

Now you should be able to visualize data from _PostgreSQL_ database, the only thing left is fill it with events from _ProconTEL_.


<div id='dotnet-connector'/>

## .NET Connector

_This is a TODO section..._