using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MusicListapi.Models;

namespace MusicListapi.Services
{
    public class SongService
    {
        private readonly IMongoCollection<Song> _songs;

        public SongService(IMusicDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _songs = database.GetCollection<Song>(settings.MusicCollectionName)
                .WithWriteConcern(new WriteConcern(
                    w: 1,
                    wTimeout: default(TimeSpan?),
                    fsync: true,
                    journal: false
                ));
        }

        public List<Song> Get() =>
            _songs.Find(song => true).ToList();

        public Song Get(string id) =>
            _songs.Find<Song>(song => song.Id == id).FirstOrDefault();


        public Song Create(Song song)
        {
            _songs.InsertOne(song);
            return song;
        }

        public void Remove(string id) =>
            _songs.DeleteOne(song => song.Id == id);

        public void Update(string id, Song songIn) =>
            _songs.ReplaceOne(song => song.Id == id, songIn);
    }
}