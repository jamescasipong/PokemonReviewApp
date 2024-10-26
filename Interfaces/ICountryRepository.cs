﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int countryId);

        ICollection<Owner> GetOwnersFromCountry(int countryId);
        bool CountryExist(int id);

    }
}
