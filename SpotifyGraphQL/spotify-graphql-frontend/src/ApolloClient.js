import { ApolloClient, InMemoryCache, createHttpLink } from "@apollo/client";
import { setContext } from "@apollo/client/link/context";

const createApolloClient = (token) => {
    const httpLink = createHttpLink({
        uri: "https://localhost:5034/graphql"
    });

    const authLink = setContext((_, {headers}) => {
        return {
            headers: {
                ...headers,
                Authorization: token ? `Bearer ${token}` : "",
            },
        };
    });

    return new ApolloClient({
        link: authLink.concat(httpLink),
        cache: new InMemoryCache()
    });
}

export default createApolloClient;