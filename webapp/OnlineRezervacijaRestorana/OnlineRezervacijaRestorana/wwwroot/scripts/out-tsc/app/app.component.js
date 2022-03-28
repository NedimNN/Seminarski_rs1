import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { MojConfig } from './mojconfig';
let AppComponent = class AppComponent {
    constructor(httpKlijent) {
        this.httpKlijent = httpKlijent;
        this.title = 'RezervacijaRestorana';
        this.odabraniRestoran = {
            name: "",
            description: "",
            city_name: "",
            priceRange: 0,
        };
    }
    checkForm() {
        var test = false;
        if (this.odabraniRestoran.name.length <= 2) {
            alert("Restaurant name must be longer that 2 characters!");
            return test;
        }
        if (this.odabraniRestoran.description.length <= 5) {
            alert("Restaurant description must be longer that 5 characters!");
            return test;
        }
        var citydata;
        if (this.httpKlijent.get(MojConfig.adresa + "GetCities").subscribe((povratnaVrijednost) => {
            citydata = povratnaVrijednost;
            var brojac = 0;
            for (var city in citydata) {
                if (citydata[city].name.toLowerCase() == this.odabraniRestoran.city_name.toLowerCase()) {
                    brojac++;
                }
            }
            ;
            if (brojac == 0) {
                alert("City name does not exist in the database! Try a different one");
                return false;
            }
            else {
                return true;
            }
            ;
        })) {
            test = true;
        }
        else {
            test = false;
        }
        ;
        return test;
    }
    snimi() {
        if (this.checkForm()) {
            this.httpKlijent.post(MojConfig.adresa + "PostRestaurant", this.odabraniRestoran)
                .subscribe((povratnaVrijednost) => {
                alert("Successfully added the restaurant: " + povratnaVrijednost.name);
                window.location.reload();
            });
        }
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css']
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map