--
-- PostgreSQL database dump
--

-- Dumped from database version 11.7 (Ubuntu 11.7-0ubuntu0.19.10.1)
-- Dumped by pg_dump version 11.7 (Ubuntu 11.7-0ubuntu0.19.10.1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.products (
    product_uid uuid NOT NULL,
    name character varying(25),
    division character varying(25),
    brigade character varying(25),
    battalion character varying(25),
    quantity integer,
    unit character varying(5),
    status character varying(1),
    price real
);


ALTER TABLE public.products OWNER TO postgres;

--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.products (product_uid, name, division, brigade, battalion, quantity, unit, status, price) FROM stdin;
cfedc8d8-56e9-4c2d-839b-c2308f7de1f1	Organic Fair Trade 5 Pack	Fresh Food	Fruits	Bananas	100	item	A	10.5
0c62cf4f-ba2d-4973-92b3-7712ab5a6114	Small Ripe 6 Pack	Fresh Food	Fruits	Bananas	100	item	A	9.19999981
79e7f2fd-dcbb-4cb4-827c-819476b5c445	Organic pears 450G	Fresh Food	Fruits	Apples&Pears	100	item	A	9.19999981
66ffa954-6182-48f8-813e-0682d7e172e8	Jazz Apple 6 pack	Fresh Food	Fruits	Apples&Pears	100	item	A	9.19999981
13b0b57d-3589-4d97-9cf8-cbfa9123efd3	Perfectly Ripe pears	Fresh Food	Fruits	Apples&Pears	100	item	A	9.19999981
b12441f2-1103-4643-a636-206743de269e	Gala apple	Fresh Food	Fruits	Apples&Pears	100	item	A	9.19999981
9cfaa707-8ea0-469a-8f4d-5f22d697d12c	Strawberries 600G	Fresh Food	Fruits	Berries&Cherries	100	item	A	9.19999981
70cba70d-64c1-4092-8e80-3af15f37af17	Blueberries	Fresh Food	Fruits	Berries&Cherries	100	item	A	9.19999981
b8a7a209-f3e8-41f1-9420-c59f1651f537	Rozedene Frarm berries	Fresh Food	Fruits	Berries&Cherries	100	item	A	9.19999981
1b690483-444c-490b-8759-92760dbbc2bb	Organic blueberries	Fresh Food	Fruits	Berries&Cherries	100	item	A	9.19999981
c983b872-1b78-4e74-82ee-a090d18e5412	Emperor Orange	Fresh Food	Fruits	Citrus Fruit	100	item	A	2.5
dfd95cbb-f2d1-487e-b95c-b9acfef28170	Lemons	Fresh Food	Fruits	Citrus Fruit	100	kg	A	8.5
eb0fef0a-64b5-418d-8578-01faad3e3220	Red Oranges	Fresh Food	Fruits	Citrus Fruit	100	item	A	9.5
fc638d6a-0852-4952-83b2-ae47b2f50e9b	Clementine	Fresh Food	Fruits	Citrus Fruit	100	kg	A	11.5
a8f745db-79b3-470a-832f-d18f45028353	Seedless Grapes	Fresh Food	Fruits	Grapes	100	item	A	2.5
a0827175-16ab-4da2-ad60-93d4d75e9406	Green grapes	Fresh Food	Fruits	Grapes	100	kg	A	8.5
250b8809-5083-44ca-8081-1db1fdeec468	Black Grapes	Fresh Food	Fruits	Grapes	100	item	A	9.5
4243bcbb-975a-45ec-9ff9-976060aeb4b9	Red Grapes	Fresh Food	Fruits	Grapes	100	kg	A	11.5
57ee6d00-96a1-4cfc-b8c0-f352f8ba404d	Walnuts 100G	Fresh Food	Fruits	Dried Fruit	100	item	A	2.5
d1556ba7-ea09-4709-9f65-c6fac6e640e7	Pitted Dates	Fresh Food	Fruits	Dried Fruit	100	kg	A	8.5
ced9b0eb-761b-4dbe-8eec-ce8ddcc1d64b	Cashew 150G	Fresh Food	Fruits	Dried Fruit	100	item	A	9.5

bf29b7f8-221c-4537-acbd-2a0f67f12e5a	Fruit&Nuts Mix	Fresh Food	Fruits	Dried Fruit	100	kg	A	11.5
d7e4f339-95af-4ee4-9728-885ae2a0529b	Sweet Bananas	Fresh Food	Fruits	Bananas	999	kg	A	2.5
c37ac885-44ee-4238-bd15-dcf427bd6af0	WhiteFarmhouseBread	Bakery	Bread	WhiteBread	1	item	A	3.5
6cd0dece-3494-4e48-94e0-9d3445c5649c	Slicedbread	Bakery	Bread	WhiteBread	1	item	A	4.5
59501999-7e83-45e5-b0e0-18fcd501ab59	FitBread	Bakery	Bread	WholegrainBread	1	item	A	6
8bffbc73-5f98-4a2c-9a28-32492c2dde65	Slicedbread	Bakery	Bread	WholegrainBread	1	item	A	4.5
ed1b6434-abac-4b76-b562-b12f3aeaa4c8	Ciabatta	Bakery	Bread	WhiteBread	1	item	A	2
f4e7e846-402e-4e53-8623-810c49f4c169	AllButtercroissant	Bakery	Pastries	Croissants	1	item	A	1.5
5500e553-d5ac-4ab7-ab37-0a7abe0268fe	AlmondCroissant	Bakery	Pastries	Croissants	1	item	A	2.5
93d22e6c-7256-46a8-ac5a-baabb765a76f	CinammonBun	Bakery	Pastries	Brioche	1	item	A	3
08dfc461-ffb6-4422-992e-29ac840381c7	CardammonBun	Bakery	Pastries	Brioche	1	item	A	3.5
1a074a6d-d5be-483f-bce8-e19a99c4d992	PortugeseCustard	Bakery	Pastries	Brioche	1	item	A	2.5
6a12786e-58c0-4439-88ed-9eab6667e13e	StrawberryIcedDoughnut	Bakery	Cookies	Doughnuts	1	pack	A	2
5c5efe0b-10d7-4d66-85b1-263db586edb2	BerryIcedDoughnut	Bakery	Cookies	Doughnuts	1	pack	A	2
939b3549-d7fd-41d7-bc1c-b9c8288205c5	CaramelIcedDoughnut	Bakery	Cookies	Doughnuts	1	pack	A	2
62f23ff4-515a-4208-880d-b3417a3aff42	TripleChocolateCookie	Bakery	Cookies	AmericanCookies	1	pack	A	19
83c7ab9c-5c51-4c94-912c-96148c6acf96	WhiteChocolateCookie	Bakery	Cookies	AmericanCookies	1	pack	A	19
2bac3e2c-6afd-40fd-8798-ae38ce4bda69	CheeseCake	Bakery	Cakes	BirthdayCakes	1	item	A	15
23493a75-2e7d-4765-9e6c-f4261dfcf1b9	DoubleChocolateCake	Bakery	Cakes	BirthdayCakes	1	item	A	20
9837d8cd-30b0-491f-aca5-87df8415dc37	ApplePie	Bakery	Cakes	PiesandTarts	1	item	A	9
1993bf44-23e1-4399-8dd7-f69ad681d1b8	RhubarbCramble	Bakery	Cakes	PiesandTarts	1	item	A	9
a455676e-7146-4bcb-aff2-da800fb2c2b4	RaspberryPie	Bakery	Cakes	PiesandTarts	1	item	A	10
e8af37a9-d21c-4c26-a96c-eafac6b503b6	Mango Królewskie	Fresh Food	Fruits	Grapes	233	kg	A	34.5
d213c883-8e69-4f26-ad0a-adcfe93d60ab	English Breakfast 80 Bags	Drinks	Tea	Black Tea	1	item	A	5
1456e787-1d48-4789-a434-6fc31af54f9a	Twining Ceylon 50 Bags	Drinks	Tea	Black Tea	1	item	A	3.29999995
28dd8745-0b47-4168-9e44-b19eeb66c73f	Organic White 26 Bags	Drinks	Tea	White Tea	1	item	A	1.79999995
dc8ba565-5c5c-411c-9065-222d2e7a2b2a	Twining Loose 46 Bags	Drinks	Tea	Leaf Tea	1	item	A	3
9e9ac911-7bea-4d3d-ac2f-42d8bd58ce20	Earl Grey Leaf 80 Bags	Drinks	Tea	Leaf Tea	1	item	A	5
6e3c9531-429e-4354-a93c-642bfe91ae8f	Lemon & Ginger 80 Bags	Drinks	Tea	Fruit Tea	1	item	A	4.5
f9610ec0-30ea-4b91-bf82-210153a29f7f	Pepermint 80 Bags	Drinks	Tea	Fruit Tea	1	item	A	4.5
e42673a4-a3bb-443f-9962-9d0a875e8701	Vanila 80 Bags	Drinks	Tea	Fruit Tea	1	item	A	4.5
5d8241bf-fdb1-4c89-8e70-68767bc0af6e	Organic Mint 80 Bags	Drinks	Tea	Fruit Tea	1	item	A	4.5
0c6c088f-0ae5-4b2d-97bb-a79696b5e2da	Twinings Green 80 Bags	Drinks	Tea	Green Tea	1	item	A	3.5
c9277f08-514d-413c-b3d0-6166d9ea6feb	Organic Green 20 Bags	Drinks	Tea	Green Tea	1	item	A	2.79999995
a95a34f4-0793-466c-a2f6-ea8300d282ce	Tulsi Herbal 20 Bags	Drinks	Tea	Herbal Tea	1	item	A	2.79999995
9a9393e2-6272-4439-8814-b7f00f816db6	Echinacea Organic 20 Bags	Drinks	Tea	Herbal Tea	1	item	A	2.79999995
eb87b35f-266a-457f-ac13-17c21c16b77e	Organic Latte 90g	Drinks	Coffee	Latte	1	item	A	7
d6c9b263-1c5b-4251-bd33-4d37fba3ac1d	Nescafe Gold Latte 200g	Drinks	Coffee	Latte	1	item	A	6.5
229cffc4-d5f6-460b-b873-cb382d5abbd6	Lavazza Beans 1kg	Drinks	Coffe	Coffe Beans	1	item	A	13.75
d416539f-2332-404f-9214-cb0d2f28a051	Lavazza Beans 250g	Drinks	Coffe	Coffe Beans	1	item	A	4.0999999
5f9e16de-8554-4924-9693-c2b39df8a439	Rossa Ground Coffe 250g	Drinks	Coffe	Ground Coffee	1	item	A	3.5999999
eb35057c-5af5-4aef-9535-98c2ee7888a2	Nescafe Gold 275g	Drinks	Coffee	Instant Coffee	1	pack	A	8.97999954
afd2367b-489f-45ee-a96c-6a2b93b71d90	Nescafe Original 200g	Drinks	Coffee	Instant Coffee	1	pack	A	4
aa151abe-c11f-46e7-bb84-7f4b865a346d	Nescafe Decaffe 200g	Drinks	Coffee	Decaf Coffee	1	pack	A	3.4000001
dec9ee27-0a88-4056-a71a-7a596713aa73	Nescafe Mocha 200g	Drinks	Coffee	Coffee Latte	1	pack	A	3
ad3b1876-45b5-4ccf-877d-f95cbf7d35c0	Nescafe Choco Mocha 100g	Drinks	Coffee	Coffee Mocha	1	pack	A	2.5
aa52d00e-030b-4ea7-b90d-58ba13b7dca1	Pure Apple 1L	Drinks	Juices	Apple Juice	1	pack	A	1
9168e605-409b-4530-9330-81ada55f5fe9	Pure Apple 0,3L	Drinks	Juices	Apple Juice	1	pack	A	0.400000006
7056f8bf-803a-4e59-828c-87966eba965f	Sweet Mango 0,5L	Drinks	Juices	Tropical Juice	1	item	A	1.5
b44b3725-f3e9-4f89-8425-c555203b0a2d	Banana Power 1L	Drinks	Juices	Banana Juice	1	item	A	1
597fc4ee-ea70-43f7-968a-3583aa3a4e7d	Banana Power 0,3L	Drinks	Juices	Banana Juice	1	item	A	0.400000006
4009fd58-12ad-45d8-bee1-44c32fdfb8f0	Pure Orange 1L	Drinks	Juices	Orange Juice	1	item	A	1
b1a21434-f6c3-4046-afbe-6d2cc517d374	Pure Orange 0,3L	Drinks	Juices	Orange Juice	1	item	A	0.400000006
87d0c20f-b54f-4d59-834d-be4c3d864990	Tropical Mix 1L	Drinks	Juices	Tropical Juice	1	item	A	1
10f5d2bb-435a-41f3-9a77-7d0d0bc2abc1	Tropical Mix 0,3L	Drinks	Juices	Tropical Juice	1	item	A	0.400000006
7aaf4e0b-786a-4202-b778-dc5a9cd8bffe	Tropical Mix 1L	Drinks	Juices	Tropical Juice	1	item	A	1
63163a27-50e8-4e9b-82a0-e4dffebe9da1	Sweet Pineapple 1L	Drinks	Juices	Tropical Juice	1	item	A	1
\.


--
-- Name: products products_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT products_pkey PRIMARY KEY (product_uid);


--
-- PostgreSQL database dump complete
--

