CREATE TABLE public.transactions (
    transaction_uid uuid NOT NULL,
    customer_uid uuid NOT NULL,
    price_value real,
    credit_card_number character varying(16)
);


ALTER TABLE public.transactions OWNER TO postgres;


INSERT INTO transactions(transaction_uid,customer_uid,price_value,credit_card_number) 
    VALUES(uuid_generate_v4(),'1713fbb3-ee7b-4e66-bf1e-2c8360bbdfeb',45,'2345000098767777');
INSERT INTO transactions(transaction_uid,customer_uid,price_value,credit_card_number) 
    VALUES(uuid_generate_v4(),'26241446-692f-4c07-9b6e-d5937c4f6be8',10,'1256000012347890');
INSERT INTO transactions(transaction_uid,customer_uid,price_value,credit_card_number) 
    VALUES(uuid_generate_v4(),'eb6175a5-f8b7-434b-8612-42255bcb388d',22,'1234000022345678');