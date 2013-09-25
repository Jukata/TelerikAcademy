using System;
using System.Data.OleDb;
using WorkWithExcel;

class Program
{
    static void Main()
    {
        //6. Create an Excel file with 2 columns: name and score:
        //Write a program that reads your MS Excel file through the OLE DB 
        //data provider and displays the name and score row by row.
        ReadFromExcel();

        //7. Implement appending new rows to the Excel file
        InsertIntoExcel("Ivailo Kenov", 19.99);
    }

    private static void ReadFromExcel()
    {
        //6. Create an Excel file with 2 columns: name and score:
        //Write a program that reads your MS Excel file through the OLE DB 
        //data provider and displays the name and score row by row.
        string connectionString = Settings.Default.DBConnectionString;
        OleDbConnection connection = new OleDbConnection(connectionString);

        connection.Open();

        using (connection)
        {
            OleDbCommand command = new OleDbCommand("SELECT Name, Score FROM [Trainers$]", connection);

            OleDbDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string name = (string)dataReader["Name"];
                double score = (double)dataReaderSET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Products` (
  `ProductId` INT NOT NULL AUTO_INCREMENT ,
  `ProductName` VARCHAR(100) NOT NULL ,
  `BasePrice` DECIMAL NOT NULL ,
  PRIMARY KEY (`ProductId`) ,
  UNIQUE INDEX `ProductId_UNIQUE` (`ProductId` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Vendors` (
  `VendorId` INT NOT NULL AUTO_INCREMENT ,
  `VendorName` VARCHAR(100) NOT NULL ,
  PRIMARY KEY (`VendorId`) ,
  UNIQUE INDEX `VendorId_UNIQUE` (`VendorId` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Measures`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Measures` (
  `MeasureId` INT NOT NULL AUTO_INCREMENT ,
  `MeasureName` VARCHAR(45) NOT NULL ,
  `Products_ProductId` INT NOT NULL ,
  PRIMARY KEY (`MeasureId`) ,
  UNIQUE INDEX `MeasureId_UNIQUE` (`MeasureId` ASC) ,
  INDEX `fk_Measures_Products1_idx` (`Products_ProductId` ASC) ,
  CONSTRAINT `fk_Measures_Products1`
    FOREIGN KEY (`Products_ProductId` )
    REFERENCES `mydb`.`Products` (`ProductId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Products_has_Vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `mydb`.`Products_has_Vendors` (
  `Products_ProductId` INT NOT NULL ,
  `Vendors_VendorId` INT NOT NULL ,
  PRIMARY KEY (`Products_ProductId`, `Vendors_VendorId`) ,
  INDEX `fk_Products_has_Vendors_Vendors1_idx` (`Vendors_VendorId` ASC) ,
  INDEX `fk_Products_has_Vendors_Products_idx` (`Products_ProductId` ASC) ,
  CONSTRAINT `fk_Products_has_Vendors_Products`
    FOREIGN KEY (`Products_ProductId` )
    REFERENCES `mydb`.`Products` (`ProductId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Products_has_Vendors_Vendors1`
    FOREIGN KEY (`Vendors_VendorId` )
    REFERENCES `mydb`.`Vendors` (`VendorId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `mydb` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
["Score"];

                Console.WriteLine("{0,-15} | {1}", name, score);
                Console.WriteLine(new string('-', 20));
            }
        }
    }

    private static void InsertIntoExcel(string name, double score)
    {
        string connectionString = Settings.Default.DBConnectionString;
        OleDbConnection connection = new OleDbConnection(connectionString);

        connection.Open();

        using (connection)
        {
            OleDbCommand command = new OleDbCommand(
                @"INSERT INTO [Trainers$](Name, Score) 
                  VALUES(@name, @score)", connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);

            int effectedRows = command.ExecuteNonQuery();

            if (effectedRows == 1)
            {
                Console.WriteLine("Inserted succesfully.");
            }
        }
    }
}
