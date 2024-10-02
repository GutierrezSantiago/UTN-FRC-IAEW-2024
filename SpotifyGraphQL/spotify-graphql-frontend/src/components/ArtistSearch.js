import React, { useState } from 'react';
import { useQuery, gql } from '@apollo/client';

const GET_ARTISTS = gql`
  query GetArtists($name: String!) {
    artists(name: $name) {
      id
      name
      genres
      images {
        url
        height
        width
      }
    }
  }
`

function ArtistSearch() {
    const [artistName, setArtistName] = useState("");
    const { data, loading, error, refetch } = useQuery(GET_ARTISTS, 
    {
        variables: {name: artistName},
        skip: true, // No ejecutar la consulta hasta que el usuario busque    
    });
 
    const handleSearch = () => {
        if (artistName.trim() !== "") {
            refetch({ name: artistName})
        }
    };

    return (
        <div>
            <input
                type="text"
                value={artistName}
                onChange={(e) => setArtistName(e.target.value)}
                placeholder="Buscar artista"
            />
            <button onClick={handleSearch}>
                Buscar
            </button>
            {loading && <p>Buscando...</p>}
            {error && <p>Error: {error.message} </p>}

            {data && data.artists && (
                <div>
                    <h2>Resultados:</h2>
                    <ul>
                        {data.artists.map((artist) => (
                            <li key={artist.id}>
                                <h3>{artist.name}</h3>
                                <p>Géneros: {artist.genres.join(", ")}</p>
                                {artist.images.length > 0 && (
                                    <img
                                        src={artist.images[0].url}
                                        alt={artist.name}
                                        width={artist.image[0].width}
                                        height={artist.image[0].height}
                                    />
                                )}
                            </li>
                        ))}       
                    </ul>
                </div>
            )}
        </div>
    )
}

export default ArtistSearch;