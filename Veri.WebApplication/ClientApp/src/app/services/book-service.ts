import { BaseService } from "./base-service";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable()
export class BookService extends BaseService {
  constructor(
    protected httpClient: HttpClient) {
    super(httpClient, "Book");
  }

  calculateDelayPenalty(model: any): Observable<any> {
    return super.patch(model.countryId, model);
  }
}
