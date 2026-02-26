import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateStudent, IStudent } from './student/student.model';

@Injectable({
  providedIn: 'root',
})
export class StudentService {

  private apiUrl = 'https://localhost:7005/api/student'; 

  constructor(private http: HttpClient) {}

  getAll(): Observable<IStudent[]> {
    return this.http.get<IStudent[]>(this.apiUrl);
  }

  getById(id: number): Observable<IStudent> {
    return this.http.get<IStudent>(`${this.apiUrl}/${id}`);
  }

  create(dto: ICreateStudent): Observable<IStudent> {
    return this.http.post<IStudent>(this.apiUrl, dto);
  }

  update(id: number, dto: ICreateStudent): Observable<IStudent> {
    return this.http.put<IStudent>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getByEmail(email: string): Observable<IStudent> {
    return this.http.get<IStudent>(`${this.apiUrl}/email/${email}`);
  }
}
