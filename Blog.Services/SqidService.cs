﻿using Blog.Services.Interfaces;
using Sqids;

namespace Blog.Services;

public class SqidService : ISqidService
{
    SqidsEncoder<int> encoder;

    public SqidService()
    {
        encoder = new SqidsEncoder<int>(new()
        {
            MinLength = 9,
            Alphabet = "k3G7QAe51FCsPW92uEOyq4Bg6Sp8YzVTmnU0liwDdHXLajZrfxNhobJIRcMvKt",
        });
    }

    public int DecryptId(string value)
    {
        return encoder.Decode(value).First();
    }

    public string EncryptId(int id)
    {
        var result  =encoder.Encode(id);
        result += "some other new value";
        return result;
    }
}
