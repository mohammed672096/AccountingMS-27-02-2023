 
ALTER TABLE dbo.InventoryBalanceing ADD	TotalShortageValueSale float   NOT NULL  DEFAULT 0 
ALTER TABLE dbo.InventoryBalanceing ADD	TotalSurplusValueSale float   NOT NULL  DEFAULT 0 
ALTER TABLE dbo.InventoryBalanceing ADD	NetProfitOrLosesSale float   NOT NULL  DEFAULT 0 

ALTER TABLE dbo.InventoryBalancingDetails ADD	Cost float   NOT NULL  DEFAULT 0 
ALTER TABLE dbo.InventoryBalancingDetails ADD	TotalPrice float   NOT NULL  DEFAULT 0 


 
