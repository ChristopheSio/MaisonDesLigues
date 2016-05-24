CREATE TABLE HOTELCHAMBREPRIX (
ID int IDENTITY(1,1),
IDHOTEL int NOT NULL,
IDCATEGORIECHAMBRE int NOT NULL,
PRIX float NOT NULL,
PRIMARY KEY (ID,IDHOTEL,IDCATEGORIECHAMBRE),
FOREIGN KEY (IDHOTEL) REFERENCES HOTEL(CODEHOTEL),
FOREIGN KEY (IDCATEGORIECHAMBRE) REFERENCES CATEGORIECHAMBRE(ID)
)


FOREIGN KEY (IDHOTEL) REFERENCES HOTEL(CODEHOTEL),
OREIGN KEY (IDCATEGORIECHAMBRE) REFERENCES CATEGORIECHAMBRE(ID)
    
    
    
INSERT HOTELCHAMBREPRIX (IDHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (1, 1, 61.2)
INSERT HOTELCHAMBREPRIX (IDHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (1, 2, 62.2)
INSERT HOTELCHAMBREPRIX (IDHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (2, 1, 112)
INSERT HOTELCHAMBREPRIX (IDHOTEL, IDCATEGORIECHAMBRE, PRIX) VALUES (2, 2, 122)