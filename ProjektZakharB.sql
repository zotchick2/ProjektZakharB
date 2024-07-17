Create DataBase ProjektZakharB
GO
Use ProjektZakharB
GO
CREATE Table Users (
UserID int not null PRIMARY KEY,
First_Name varchar(40) not null,
Last_Name varchar(60),
Email varchar(255),
Password_Hash varchar(255) not null
);
CREATE Table Accounts (
AccountID int not null PRIMARY KEY,
UserID int not null,
CurrencyID int not null,
Account_name varchar(60) not null,
Balance Money not null,
FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
CREATE Table TypesIncomesExpenses (
TypeID Int not null PRIMARY KEY,
Types_name varchar(40),
Category varchar(10) not null
);
CREATE Table CurrencyRates (
CurrencyID int not null PRIMARY KEY,
Currency varchar(30) not null,
Rate_to_USD Money not null,
Date_updated_course Date not null Check(Date_updated_course <= getDate())
);
CREATE Table Transactions (
TransactionID int not null PRIMARY KEY,
AccountID int not null,
TypeID int not null,
CurrencyID int not null,
Amount Money not null,
Category varchar(50) not null,
Date_transaction Date not null Check(Date_transaction <= getDate()),
Descriptions varchar(500),
FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID),
FOREIGN KEY (TypeID) REFERENCES TypesIncomesExpenses(TypeID),
FOREIGN KEY (CurrencyID) REFERENCES CurrencyRates(CurrencyID)
);
CREATE Table BudgetPlan (
BudgetID int not null PRIMARY KEY,
UserID int not null,
CurrencyID int not null,
Maximum_amount_of_budget Money not null,
Category varchar(40) not null,
Month_and_year_of_planning Date not null Check(Month_and_year_of_planning > getDate()),
FOREIGN KEY (UserID) REFERENCES Users(UserID),
FOREIGN KEY (CurrencyID) REFERENCES CurrencyRates(CurrencyID)
);
CREATE Table Reminders (
ReminderID int not null PRIMARY KEY,
UserID int not null,
Text_reminder varchar(500) not null,
Date_reminder Date not null Check(Date_reminder > getDate()),
FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
INSERT INTO Users (UserID, First_Name, Last_Name, Email, Password_Hash)
VALUES
(1, 'John', 'Doe', 'john.doe@gmail.com', 'bcrypt_hash_1'),
(2, 'Jane', 'Smith', 'jane.smith@gmail.com', 'bcrypt_hash_2'),
(3, 'Alice', 'Johnson', 'alice.johnson@gmail.com', 'bcrypt_hash_3'),
(4, 'Bob', 'Williams', 'bob.williams@gmail.com', 'bcrypt_hash_4'),
(5, 'Eva', 'Brown', 'eva.brown@gmail.com', 'bcrypt_hash_5')
INSERT INTO Accounts (AccountID, UserID, CurrencyID, Account_name, Balance)
VALUES
(1, 1, 1, 'Konto podstawowe', 1000.00),
(2, 2, 2, 'Oszczędności', 5000.00),
(3, 3, 3, 'Karta kredytowa', -200.00),
(4, 4, 4, 'Konto podstawowe', 1500.00),
(5, 5, 5, 'Oszczędności', 3000.00)
INSERT INTO TypesIncomesExpenses (TypeID, Types_name, Category)
VALUES
(1, 'Wynagrodzenie', 'dochód'),
(2, 'Artykuły spożywcze', 'wydatek'),
(3, 'Czynsz', 'wydatek'),
(4, 'Przelew', 'dochód'),
(5, 'Rachunki', 'wydatek')
INSERT INTO CurrencyRates (CurrencyID, Currency, Rate_to_USD, Date_updated_course)
VALUES
(1, 'USD', 1.00, GETDATE()),
(2, 'EUR', 1.12, GETDATE()),
(3, 'GBP', 1.32, GETDATE()),
(4, 'PLN', 0.25, GETDATE()),
(5, 'BYN', 0.32, GETDATE())
INSERT INTO Transactions (TransactionID, AccountID, TypeID, Amount, CurrencyID,
Category, Date_transaction, Descriptions)
VALUES
(1, 1, 1, 1500.00, 1, 'Wynagrodzenie', GETDATE(), 'Przychód za prace'),
(2, 2, 2, 50.00, 1, 'Artykuły spożywcze', GETDATE(), 'Zakupy spożywcze'),
(3, 3, 3, 500.00, 2, 'Czynsz', GETDATE(), 'Opłata za wynajem'),
(4, 4, 4, 2000.00, 1, 'Przelew', GETDATE(), 'Przelew od przyjaciela'),
(5, 5, 5, 100.00, 1, 'Rachunki', GETDATE(), 'Opłata za prąd')
INSERT INTO BudgetPlan (BudgetID, UserID, Maximum_amount_of_budget, CurrencyID,
Category, Month_and_year_of_planning)
VALUES
(1, 1, 2000.00, 5, 'Zakupy', '2025-02-25'),
(2, 2, 500.00, 3, 'Rozrywka', '2025-02-07'),
(3, 3, 1000.00, 2, 'Opłaty', '2025-02-28'),
(4, 4, 3000.00, 1, 'Zakupy', '2025-02-23'),
(5, 5, 800.00, 4, 'Rachunki', '2025-02-27')
INSERT INTO Reminders (ReminderID, UserID, Text_reminder, Date_reminder)
VALUES
(1, 1, 'Zapłać rachunki', '2025-02-25'),
(2, 2, 'Spotkanie z przyjaciółmi', '2025-02-07'),
(3, 3, 'Przypomnienie o czynszu', '2025-02-28'),
(4, 4, 'Zakupy spożywcze', '2025-02-23'),
(5, 5, 'Przypomnienie o płatności', '2025-02-27')