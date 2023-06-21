import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
    baseUrl = 'https://localhost:5001/api/';

    constructor(private http: HttpClient) {
    }

  ngOnInit(): void {}

  get404Error(){
      this.http.get(this.baseUrl + 'error/not-found').subscribe({
        next: response => console.log(response),
        error: err => console.log(err)
      })
  }
}
