import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CountryService } from './services/country-service';
import { BookService } from './services/book-service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  formGroup: FormGroup = new FormGroup({
    checkedOutDate: new FormControl(null, Validators.required),
    returnDate: new FormControl(null, Validators.required),
    countryId: new FormControl(null, Validators.required),
  });

  countries: any[] = [];
  message: any;

  ngOnInit(): void {
    this.countryService.getAll().subscribe(c => {
      this.countries = c;
    });
  }
  constructor(
    private bookService: BookService,
    private countryService: CountryService) {

  }


  onClick() {
    if (!this.formGroup.valid) {
      alert('please enter checked out date, return date and select country, then press calculate button');
      return;
    }

    let model = {
      countryId: this.formGroup.value.countryId,
      checkedOutDate: this.formGroup.value.checkedOutDate,
      returnDate: this.formGroup.value.returnDate,
    };

    this.bookService.calculateDelayPenalty(model)
      .subscribe(result => {
        if (result.penaltyAmount > 0) {
          this.message = `You have delaied ${result.delayDays} days, so your penalty is ${this.formatNumberWithCommas(result.penaltyAmount)} ${result.currenyType}`;
        }
        else
          this.message = 'No Penalty';
      });
  }
  formatNumberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
  }
}
