CREATE TABLE Quotes
(
	Id UNIQUEIDENTIFIER NOT NULL,
	Ask MONEY NULL,
	AverageDailyVolume MONEY NULL,
	Bid MONEY NULL,
	BookValue MONEY NULL,
	Change MONEY NULL,
	ChangeFromTwoHundredDayMovingAverage MONEY NULL,
	ChangeFromYearHigh MONEY NULL,
	ChangeFromYearLow MONEY NULL,
	ChangeInPercent MONEY NULL,
	ChangePercent MONEY NULL,
	CreateDate DATETIME,
	DailyHigh MONEY NULL,
	DailyLow MONEY NULL,
	DividendPayDate DATETIME NULL,
	DividendShare MONEY NULL,
	DividendYield MONEY NULL,
	EarningsShare MONEY NULL,
	Ebitda MONEY NULL,
	EpsEstimateCurrentYear MONEY NULL,
	EpsEstimateNextQuarter MONEY NULL,
	EpsEstimateNextYear MONEY NULL,
	ExDividendDate DATETIME NULL,
	FiftyDayMovingAverage MONEY NULL,
	LastTradeDate DATETIME NULL,
	LastTradePrice MONEY NULL,
	MarketCapitalization MONEY NULL,
	Name NVARCHAR(500),
	OneYearPriceTarget MONEY NULL,
	[Open] MONEY NULL,
	PegRatio MONEY NULL,
	PeRatio MONEY NULL,
	PercentChangeFromFiftyDayMovingAverage MONEY NULL,
	PercentChangeFromTwoHundredDayMovingAverage MONEY NULL,
	PercentChangeFromYearHigh MONEY NULL,
	PercentChangeFromYearLow MONEY NULL,
	PreviousClose MONEY NULL,
	PriceBook MONEY NULL,
	PriceEpsEstimateCurrentYear MONEY NULL,
	PriceEpsEstimateNextYear MONEY NULL,
	PriceSales MONEY NULL,
	ShortRatio MONEY NULL,
	StockExchange NVARCHAR(500),
	Symbol NVARCHAR(500),
	TwoHunderedDayMovingAverage MONEY NULL,
	Volume MONEY NULL,
	YearlyHigh MONEY NULL,
	YearlyLow MONEY NULL
)

CREATE TABLE Investments
(
	Id UNIQUEIDENTIFIER NOT NULL,
	PlayerName NVARCHAR(20),
	Symbol NVARCHAR(500),
	PurchaseDate DATETIME,
	Quantity INTEGER,
	SellDate DATETIME NULL,
	PurchasePrice MONEY,
	SellPrice MONEY NULL,
	SellReason INTEGER
)

CREATE TABLE Logs
(
	Id UNIQUEIDENTIFIER NOT NULL,
	CreateDate DATETIME,
	[Type] INTEGER,
	[Text] VARCHAR(8000)
)