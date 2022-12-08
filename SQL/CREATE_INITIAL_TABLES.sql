use mitien
GO

create table DOCUMENT_TYPE
(
    ID integer identity not null,
    DESCRIPTION varchar(200) not null,
    
    CONSTRAINT pk_documenttype primary key (ID)
)
GO

create table VEHICLE_CATEGORY
(
    ID integer identity not null,
    NAME varchar(200) not null,
    INITIALS varchar(10),
    DESCRIPTION varchar(200),

    CONSTRAINT pk_vehiclecategory primary key (ID)
)
GO

create table ACCESSORY_TYPE
(
   ID integer identity not null,
   NAME varchar(200) not null,

   CONSTRAINT pk_accessorytype primary key (ID)
)
GO

create table MATERIAL
(
    ID integer identity not null,
    NAME varchar(200) not null,
    DESCRIPTION varchar(200),

    CONSTRAINT pk_material primary key (ID)
)
GO

create table ACCESSORY
(
    ID integer identity not null,
    NAME varchar(200) not null,
    TYPE integer not null,
    MATERIAL integer not null,

    CONSTRAINT pk_accessory primary key (ID),
    CONSTRAINT fk_accessory_accessorytype foreign key (TYPE) references ACCESSORY_TYPE (ID),
    CONSTRAINT fk_accessory_material foreign key (MATERIAL) references MATERIAL (ID)
)
GO

create table LOCATION
(
    ID integer identity not null,
    NAME varchar(2000) not null,
    ADDRESS varchar(1000) not null,
    CITY varchar(200),

    CONSTRAINT pk_location primary key (ID)
)
GO

create table VEHICLE
(
    ID integer identity not null,
    NAME varchar(200) not null,
    VEHICLE_CATEGORY integer not null,
    VEHICLE_LOCATION integer not null,
    VEHICLE_ACCESSORIES integer not null,
    RENTAL_PRICE decimal not null,
    GAS_LEVEL integer not null,
    LICENSE_PLATE varchar(8) not null,
    CHASSI char(17) not null,
    REGISTRY_NUMBER char(11) not null,

    CONSTRAINT pk_vehicle primary key (ID),
    CONSTRAINT fk_vehicle_vehiclecategory foreign key (VEHICLE_CATEGORY) references VEHICLE_CATEGORY (ID),
    CONSTRAINT fk_vehicle_vehiclelocation foreign key (VEHICLE_LOCATION) references LOCATION (ID),
    CONSTRAINT fk_vehicle_vehicleaccessory foreign key (VEHICLE_ACCESSORIES) references ACCESSORY (ID)
)
GO

create table USER_TYPE
(
    ID integer identity not null,
    DESCRIPTION varchar(200) not null,

    CONSTRAINT pk_usertype primary key (ID)
)
GO

create table USERS
(
    ID integer identity not null,
    EMAIL varchar(300) not null,
    PASSWORD varbinary(256),
    NAME varchar(1000) not null,
    DOCUMENT_TYPE integer not null,
    CPF char(11),
    FOREIGN_DOCUMENT varchar(100),
    PASSPORT_NUMBER integer,
    PHONE_NUMBER varchar(50),
    BIRTHDAY datetime not null,
    USER_TYPE integer not null,
    REGISTER_NUMBER integer,
    CREDIT_CARD_NUMBER integer,

    CONSTRAINT pk_users primary key (ID),
    CONSTRAINT fk_users_documenttype foreign key (DOCUMENT_TYPE) references DOCUMENT_TYPE (ID),
    CONSTRAINT fk_users_usertype foreign key (USER_TYPE) references USER_TYPE (ID)
)
GO

create table RENTAL
(
    ID integer identity not null,
    CLIENT integer not null,
    VEHICLE integer not null,
    PICKUP_LOCATION integer not null,
    DROPOFF_LOCATION integer not null,
    PICKUP_DATETIME datetime not null,
    DROPOFF_DATETIME  datetime not null,
    ESTIMATED_PRICE decimal (9,2) not null,
    FINAL_PRICE decimal (9,2) not null,

    CONSTRAINT pk_rental primary key (ID),
    CONSTRAINT fk_rental_client foreign key (CLIENT) references USERS (ID),
    CONSTRAINT fk_rental_vehicle foreign key (VEHICLE) references VEHICLE (ID)
)
GO