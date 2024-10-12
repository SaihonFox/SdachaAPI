drop database if exists diplom;

create database diplom;
use diplom;

create table user(
	id bigint unsigned primary key auto_increment,
    surname text not null, # Фамилия
    name text not null, # Имя
    patronym text, # Отчество
    birthday date not null,
    passport varchar(10),
    phone varchar(11),
    post tinyint, # 1 - Администратор, 2 - Врач, 3 - Оператор (поддержка)
    
    login varchar(20) not null,
    password varchar(20) not null default "123",
    
    image longblob
);
insert into user(surname, name, birthday, passport, phone, post, login) values
("Тулькубаев", "Ильнар", "2005-04-22", "8019634345", "89654426543", 1, "ilnar"),
("Кузовкина", "Виктория", "2005-02-03", "8019634543", "89654425643", 2, "vikak"),
("Ахмадуллин", "Айрат", "2005-11-04", "8019634453", "89654426534", 3, "irat");

create table patient(
	id bigint unsigned primary key auto_increment,
    surname text not null, # Фамилия
    name text not null, # Имя
    patronym text, # Отчество
    birthday date not null,
    passport varchar(10),
    phone varchar(11),
    email text not null,
    sex enum("Мужской", "Женский"),
    
    login text not null,
    password text not null,
    
    image longblob
);

create table analysis_category(
	id int primary key auto_increment,
    name text not null
);
insert into analysis_category(name) values
("Другое");

# Список анализов
create table analysis(
	id bigint unsigned primary key auto_increment,
    name text not null,
    description text,
    preparation text, # подготовка
    results_after datetime not null, # результаты через (промежуток времени, н/п: 1 день, 2 часа, 2 дня и т.д.)
    biomaterial text not null,
    price decimal(10, 2) not null,
    analyses_category_id int not null references analysis_category(id),
    
    foreign key (analyses_category_id) references analysis_category(id)
);

# Корзина
create table patient_analysis_cart(
	id bigint unsigned primary key auto_increment,
    patient_id bigint unsigned references patient(id),
    
    foreign key (patient_id) references patient(id)
);

# Анализы в корзине
create table patient_analysis_cart_item(
	id bigint unsigned primary key auto_increment,
    count int unsigned not null,
    analysis_id bigint unsigned not null references analysis(id),
    patient_analysis_cart_id bigint unsigned not null references patient_analysis_cart(id),
    
    foreign key (analysis_id) references analysis(id),
    foreign key (patient_analysis_cart_id) references patient_analysis_cart(id)
);

# Адрес сдачи анализов
create table patient_analysis_address(
	id bigint unsigned primary key auto_increment,
    address text not null, # адрес доставки
    floor int, # этаж клиента
    room int, # номер квартиры
    entrance int, # номер подъезда
    intercome text # номер домофона
);

# Текущие анализы которые проходит пациент
create table analysis_order(
	id bigint unsigned primary key auto_increment,
    user_id bigint unsigned references user(id), # лечащий врач
    patient_id bigint unsigned references patient(id),
    
    patient_analysis_cart_id bigint unsigned references patient_analysis_cart(id),
	
    analysis_datetime datetime not null, # время сдачи анализов
    comment text,
    patient_analysis_address_id bigint unsigned not null references patient_analysis_address(id),
    
    foreign key (user_id) references user(id),
    foreign key (patient_id) references patient(id),
    
    foreign key (patient_analysis_address_id) references patient_analysis_address(id)
);



# Пациенту может писать не только лечащий врач, но и оператор
# И потому у сообщения не будет user id, только patient id
# User id будет иметься у сообщения отправителя пациенту
# Это позволит нескольким user id писать пациенту

# Сообщения
create table messages(
	id bigint unsigned primary key auto_increment,
    patient_id bigint unsigned not null references patient(id),
    
    foreign key (patient_id) references patient(id)
);

create table messages_message(
	id bigint unsigned primary key auto_increment,
    messages_id bigint unsigned references messages(id),
    message text,
    time datetime not null,
    
    user_id bigint unsigned references user(id),
    patient_id bigint unsigned references patient(id),
    
    foreign key (messages_id) references messages(id),
    foreign key (user_id) references user(id),
    foreign key (patient_id) references patient(id)
);



# Реклама и рекламные блоки
create table ad_block(
	id bigint unsigned primary key auto_increment,
    name text not null,
    description text,
    sex text, # null is unisex
    price decimal(10, 2) not null,
    date_start datetime,
    date_end datetime,
    
    analysis_id bigint unsigned references analysis(id),
    
    foreign key (analysis_id) references analysis(id)
);