import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Employee } from '../models/interfaces/employee.interface';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private _baseUrl: string = environment.baseUrl;

  constructor(private _httpClient: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this._httpClient.get<Employee[]>(`${this._baseUrl}/employees`);
  }

  getEmployeeById(id: number | string): Observable<Employee> {
    return this._httpClient.get<Employee>(`${this._baseUrl}/employees/${id}`);
  }
}
