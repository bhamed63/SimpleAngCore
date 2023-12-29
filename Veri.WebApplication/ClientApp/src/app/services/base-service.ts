import { Component, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class BaseService {


  private baseUrl: string = 'http://localhost:47348/api/';
  constructor(
    protected httpClient: HttpClient,
    protected resourceName: string) {
  }

  getAll(): Observable<any> {
    let url = this.baseUrl + this.resourceName;
    return this.httpClient.get<any[]>(url)
      .pipe(
        tap(heroes => { }));
  }

  patch(id: any, model: any): Observable<any> {
    let url = this.baseUrl + this.resourceName + '/' + id;
    return this.httpClient.patch<any>(url, model, httpOptions).pipe(
      tap(heroes => { }));
  }

}
