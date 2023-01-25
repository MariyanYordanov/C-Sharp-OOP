// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	//using FestivalManager.Entities;
	using NUnit.Framework;
	using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
	{
		[Test]
		public void test1()
		{
			Stage stage = new Stage();
			Assert.IsNotNull(stage);
		}

		[Test]
		public void AddPerformerTest()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			stage.AddPerformer(performer);
			Assert.IsNotNull(stage);
			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void AddPerformerThrowException()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 13);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
			Assert.AreEqual(0, stage.Performers.Count);
		}

		[Test]
		public void AddSong()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Song song = new Song("sasa", timeSpan);
			stage.AddSong(song);
			Assert.IsNotNull(stage);
		}

		[Test]
		public void AddSongThrowException()
		{
			Stage stage = new Stage();
			TimeSpan timeSpan = new TimeSpan(0, 0, 32);
			Song song = new Song("sasa", timeSpan);
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void AddSongToPerformerTest()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Song song = new Song("sasa", timeSpan);

			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			Assert.IsNotNull(stage);


		}

		[Test]
		public void GetPerformerThrowException()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Song song = new Song("sasa", timeSpan);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer(song.Name, performer.FullName);

		}

		[Test]
		public void PlayWorkCorectly()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Song song = new Song("sasa", timeSpan);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer(song.Name, performer.FullName);
			stage.Play();

			Assert.AreEqual(1, performer.SongList.Count);
			Assert.IsNotNull(song);

		}

		[Test]
		public void AddPerformerCheck2()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			stage.AddPerformer(performer);
			var perf = stage.Performers.FirstOrDefault();

			Assert.AreEqual(perf, performer);
			Assert.AreEqual(1,stage.Performers.Count);
		}

		[Test]
		public void ValidateNullValueCheck()
		{
			Stage stage = new Stage();
			Song song = null;
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
		}

		[Test]
		public void GetRepformerThrowEx()
        {
			Stage stage = new Stage();
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Performer performer = new Performer("sas", "asas", 23);
			Song song = new Song("sasa", timeSpan);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name,"Rer Mes"));
        }

		[Test]
		public void GetSongThrow()
        {
			Stage stage = new Stage();
			TimeSpan timeSpan = new TimeSpan(0, 22, 21);
			Song song = new Song("sasa", timeSpan);
			Performer performer = new Performer("sas", "asas", 23);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("das", performer.FullName));
		}

		[Test]
		public void PlayCheck()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			Song song1 = new Song("Song1", new TimeSpan(0, 3, 33));
			Song song2 = new Song("Song2", new TimeSpan(0, 3, 33));
			Song song3 = new Song("Song3", new TimeSpan(0, 3, 33));

			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSong(song3);

			stage.AddPerformer(performer);
			stage.AddSongToPerformer("Song1", performer.FullName);
			stage.AddSongToPerformer("Song2", performer.FullName);
			stage.AddSongToPerformer("Song3", performer.FullName);

			Assert.AreEqual($"{stage.Performers.Count} performers played 3 songs", stage.Play());
		}

		[Test]
		public void AddSongToPerformer()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("sas", "asas", 23);
			Song song = new Song("Song", new TimeSpan(0, 3, 30));
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("Song", performer.FullName);

			Assert.AreEqual("sas asas", performer.FullName);
			Assert.AreEqual(song, performer.SongList[0]);
			Assert.AreEqual(1, performer.SongList.Count);
		}

		[Test]
		public void AddSongCheck2()
		{
			Stage stage = new Stage();
			Song song = new Song("Song", new TimeSpan(0, 1, 59));
			Performer performer = new Performer("sas", "asas", 23);
			stage.AddPerformer(performer);
			stage.AddSong(song);

			Assert.AreEqual($"Song (01:59) will be performed by sas asas", stage.AddSongToPerformer(song.Name,performer.FullName));
		}
	}
}