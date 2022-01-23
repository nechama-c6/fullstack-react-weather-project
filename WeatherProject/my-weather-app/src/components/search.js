import React from 'react';
import Autosuggest from 'react-autosuggest';
import { Button } from 'react-bootstrap';
import './search.css';

class Search extends React.Component {
    constructor(props) {
        super(props);

        //Define state for value and suggestion collection
        this.state = {
            value: '',
            key: '',
            suggestions: [],
            allSuggestions: [] = [],
        };
    }

    // Filter logic
    getSuggestions = async (value) => {
        const inputValue = value.trim().toLowerCase();
        if (this.state.allSuggestions) {
            var existingSuggestion = this.state.allSuggestions.find(e => e.key == inputValue)
            if (existingSuggestion)
                return existingSuggestion.suggestions;
        }
        let response = await fetch(`${process.env.REACT_APP_WEATHER_CITIES_API_URL}?apikey=${process.env.REACT_APP_WEATHER_API_KEY}&q=` + inputValue);
        let data = await response.json()
        this.setState({
            allSuggestions: [...this.state.allSuggestions, { key: inputValue, suggestions: data }]
        });
        return data;
    };

    // Trigger suggestions
    getSuggestionValue = suggestion => suggestion;

    // Render Each Option
    renderSuggestion = suggestion => (
        <span className="sugg-option">
            <span className="name">
                {suggestion.LocalizedName} ({suggestion.Country.LocalizedName})
            </span>
        </span>
    );

    // OnChange event handler
    onChange = (event, { newValue }) => {
        if (newValue.Key) {
            this.setState({
                value: newValue.LocalizedName,
                key: newValue.Key
            });
            this.props.citySelected(newValue.Key);
        }
        else {
            this.setState({
                value: newValue,
                key: ''
            });
        }
    };

    // Suggestion rerender when user types
    onSuggestionsFetchRequested = ({ value }) => {
        this.getSuggestions(value)
            .then(data => {
                if (data.Error) {
                    this.setState({
                        suggestions: []
                    });
                } else {
                    this.setState({
                        suggestions: data
                    });
                }
            })
    };

    // Triggered on clear
    onSuggestionsClearRequested = () => {
        this.setState({
            suggestions: []
        });
    };

    render() {
        const { value, suggestions } = this.state;

        // Option props
        const inputProps = {
            placeholder: 'Type city name',
            value,
            onChange: this.onChange
        };

        return (
            <div className='flex'>
                <Autosuggest
                    suggestions={suggestions}
                    onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
                    onSuggestionsClearRequested={this.onSuggestionsClearRequested}
                    getSuggestionValue={this.getSuggestionValue}
                    renderSuggestion={this.renderSuggestion}
                    inputProps={inputProps}
                />
                <Button disabled={this.state.key == ''} variant='primary' className='btn' onClick={() => this.props.addFavorite(this.state.key)}>Add city to favorites</Button>
            </div>
        );
    }
}

export default Search;