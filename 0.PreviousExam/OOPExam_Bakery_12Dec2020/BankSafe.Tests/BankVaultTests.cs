using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        Dictionary<string, Item> vaultTestCells;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Marsteyor", "79");

            vaultTestCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        [Test]
        public void BankItemWorkProperly()
        {
            Assert.AreEqual("Marsteyor",item.Owner);
            Assert.AreEqual("79", item.ItemId);
        }

        [Test]
        public void BankVault_WorkProperly()
        {
            Assert.IsNotNull(bankVault);
            
            Assert.AreEqual(12,bankVault.VaultCells.Count);
            Assert.AreEqual(vaultTestCells.ContainsKey("A1"), bankVault.VaultCells.ContainsKey("A1"));
            Assert.AreEqual(vaultTestCells.ContainsKey("A2"), bankVault.VaultCells.ContainsKey("A2"));
            Assert.AreEqual(vaultTestCells.ContainsKey("A3"), bankVault.VaultCells.ContainsKey("A3"));
            Assert.AreEqual(vaultTestCells.ContainsKey("A4"), bankVault.VaultCells.ContainsKey("A4"));
            Assert.AreEqual(vaultTestCells.ContainsKey("B1"), bankVault.VaultCells.ContainsKey("B1"));
            Assert.AreEqual(vaultTestCells.ContainsKey("B2"), bankVault.VaultCells.ContainsKey("B2"));
            Assert.AreEqual(vaultTestCells.ContainsKey("B3"), bankVault.VaultCells.ContainsKey("B3"));
            Assert.AreEqual(vaultTestCells.ContainsKey("B4"), bankVault.VaultCells.ContainsKey("B4"));
            Assert.AreEqual(vaultTestCells.ContainsKey("C1"), bankVault.VaultCells.ContainsKey("C1"));
            Assert.AreEqual(vaultTestCells.ContainsKey("C2"), bankVault.VaultCells.ContainsKey("C2"));
            Assert.AreEqual(vaultTestCells.ContainsKey("C3"), bankVault.VaultCells.ContainsKey("C3"));
            Assert.AreEqual(vaultTestCells.ContainsKey("C4"), bankVault.VaultCells.ContainsKey("C4"));

        }

        [Test]
        public void AddItem_Work_Properly()
        {
            string result = $"Item:{item.ItemId} saved successfully!";
            Assert.AreEqual(result, bankVault.AddItem("A1", item));
            
        }

        [Test]
        public void AddItem_Thorw_Exception()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A0", item));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item));
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", item));
        }

        [Test]
        public void Test()
        {
            bankVault.AddItem("A1", item);
            Assert.AreEqual("Marsteyor", bankVault.VaultCells["A1"].Owner);
            Assert.AreEqual("79", bankVault.VaultCells["A1"].ItemId);
        }

        [Test]
        public void RemoveItem_Work_Properly()
        {
            Item ite = new Item("Mars", "9");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", ite);
            string result = $"Remove item:{ite.ItemId} successfully!";
            Assert.AreEqual(result, bankVault.RemoveItem("A2", ite));
            Assert.AreEqual(null, bankVault.VaultCells["A2"]);
        }

        [Test]
        public void RemoveItem_Throw_Exception()
        {
            Item ite = new Item("Mars", "9");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", ite);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A0", ite));
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A3", ite));
        }
    }
}