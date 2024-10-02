import React from 'react';
import { ApolloProvider } from "@apollo/client";
import { useAuth0 } from "@auth0/auth0-react";
import createApolloClient from "./ApolloClient";
import ArtistSearch from './components/ArtistSearch';

function App() {
  const { isAuthenticated, getAccessTokenSilently, isLoading } = useAuth0();
  const [client, setClient] = React.useState(null);
  React.useEffect(() => {
    const initApollo = async () => {
      if (isAuthenticated) {
        try {
          const token = await getAccessTokenSilently();
          const ApolloClient = createApolloClient(token);
          setClient(ApolloClient);
        } catch (error) {
          console.error("Error obteniendo el token de Auth0: ", error);
        }
      }
    }
    initApollo();
  }, [isAuthenticated, getAccessTokenSilently]);

  if (isLoading) return <div>Loading...</div>;
  
  return (
    <div className="App">
      {isAuthenticated ? (
        client ? (
          <ApolloProvider client={client}>
            <h1>
              Spotify Artist Search
            </h1>
            <ArtistSearch />
          </ApolloProvider>
        ) : (
          <div>
            Loading Apollo Client...
          </div>
        )
      ) : (
        <div>
          Please log in.
        </div>
      )}
    </div>
  );
}

export default App;
