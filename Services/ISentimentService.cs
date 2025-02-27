﻿using AI_Apps.Models;

namespace AI_Apps.Services
{
    public interface ISentimentService
    {
        IEnumerable<SentimentsResponse> GetSentiments(string sentence);
    }
}
