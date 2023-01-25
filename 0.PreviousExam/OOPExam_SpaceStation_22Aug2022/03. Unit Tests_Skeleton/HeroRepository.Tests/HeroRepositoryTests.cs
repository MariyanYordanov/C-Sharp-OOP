using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero1;
    private Hero hero2;
    private Hero hero3;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        hero1 = new Hero("T1",1);
        hero2 = new Hero("T2", 2);
        heroRepository = new HeroRepository();
    }

    [Test]
    public void Constructor_Work_Properly()
    {
        Assert.IsNotNull(hero1);
        Assert.IsNotNull(heroRepository);
    }

    [Test]
    public void Property_Work_Properly() 
    {
        Assert.AreEqual("T1", hero1.Name);
        Assert.AreEqual(1, hero1.Level);
        Assert.AreEqual(0,heroRepository.Heroes.Count);
    }
    
    [Test]
    public void Create_Work_Properly()
    {
        heroRepository.Create(hero1);
        List<Hero> data = new List<Hero>();
        data.Add(hero1);
        CollectionAssert.AreEqual(data, heroRepository.Heroes);
        string result = $"Successfully added hero T1 with level 1";
        Assert.AreEqual(result, $"Successfully added hero {hero1.Name} with level {hero1.Level}");
    }

    [Test]
    public void Create_Throw_Exception()
    {
        heroRepository.Create(hero1);
        Assert.Throws<ArgumentNullException>(() =>heroRepository.Create(hero3), "Hero is null");
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero1), $"Hero with name T1 already exists");
    }

    [Test]
    public void Remove_Work_Properly()
    {
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        heroRepository.Remove(hero2.Name);
        List<Hero> data = new List<Hero>();
        data.Add(hero1);
        CollectionAssert.AreEqual(data, heroRepository.Heroes);
        Assert.IsTrue(heroRepository.Remove(hero1.Name));
    }

    [Test]
    public void Remove_Throw_Exception()
    {
        heroRepository.Create(hero1);
        Hero hero = new Hero("", 4);
        Assert.Throws<ArgumentNullException>(()=> heroRepository.Remove(hero.Name), "Name cannot be null");
    }

    [Test]
    public void GetHeroWithHighestLevel_Work_Properly()
    {
        heroRepository.Create(hero1);
        heroRepository.Create(hero2);
        Assert.AreSame(hero2,heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero_Work_Properly()
    {
        heroRepository.Create(hero1);
        Assert.AreSame(hero1, heroRepository.GetHero(hero1.Name));
    }
}