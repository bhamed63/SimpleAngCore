import { BaseService } from "./base-service";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class CountryService extends BaseService {
  constructor(protected httpClient: HttpClient) {
    super(httpClient, "Country");
  }
}
