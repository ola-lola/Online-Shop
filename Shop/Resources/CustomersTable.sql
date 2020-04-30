CREATE TABLE public.customers (
    customer_uid uuid NOT NULL,
    name character varying(25),
    surname character varying(25),
    email character varying(25),
    delivery_address character varying(40),
    tel_number character varying(9),
    nick character varying(25) UNIQUE,
    password character varying(25),
    credit_card_number character varying(16)
);


ALTER TABLE public.customers OWNER TO postgres;


INSERT INTO customers(customer_uid,name,surname,email,delivery_address,tel_number,nick,password,credit_card_number) 
    VALUES(uuid_generate_v4(),'Anna','Kowalska','annak@gmail.com','ul. Marszalkowska 5, Warszawa','123567432','annak','mypassabc','2345000098767777');
INSERT INTO customers(customer_uid,name,surname,email,delivery_address,tel_number,nick,password,credit_card_number) 
    VALUES(uuid_generate_v4(),'Karolina','Kowalska','kk@gmail.com','ul. Dobra 5, Warszawa','987999000','kk999','karolina78','1256000012347890');
INSERT INTO customers(customer_uid,name,surname,email,delivery_address,tel_number,nick,password,credit_card_number) 
    VALUES(uuid_generate_v4(),'Adam','Nowak','adam.nowak@gmail.com','ul. Grojecka 5, Warszawa','334567123','adamnowy','ul89OO','1234000022345678');