import { Component, OnInit } from '@angular/core';
import { ICreateStudent, IStudent } from './student.model';
import { StudentService } from '../student.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student',
  imports: [FormsModule,CommonModule],
  templateUrl: './student.html',
  styleUrl: './student.css',
})
export class Student implements OnInit {

  students: IStudent[] = [];

  form: ICreateStudent = {
    name: '',
    email: ''
  };

  showForm = false;
  isEditing = false;
  editingId: number | null = null;

  loading = false;
  successMsg = '';
  errorMsg = '';

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.loading = true;

    this.studentService.getAll().subscribe({
      next: (data) => {
        this.students = data;
        this.loading = false;
      },
      error: (err) => {
        this.errorMsg = err.error?.message || 'Error loading students';
        this.loading = false;
      }
    });
  }

  openCreate() {
    this.isEditing = false;
    this.form = { name: '', email: '' };
    this.showForm = true;
    this.errorMsg = '';
  }

  openEdit(student: IStudent) {
    this.isEditing = true;
    this.editingId = student.id;

    this.form = {
      name: student.name,
      email: student.email
    };

    this.showForm = true;
    this.errorMsg = '';
  }

  saveStudent() {

    if (this.isEditing && this.editingId !== null) {

      this.studentService.update(this.editingId, this.form)
        .subscribe({
          next: () => {
            this.successMsg = 'Student updated successfully';
            this.afterSave();
          },
          error: (err) => {
            this.errorMsg = err.error?.message || 'Update failed';
          }
        });

    } else {

      this.studentService.create(this.form)
        .subscribe({
          next: () => {
            this.successMsg = 'Student created successfully';
            this.afterSave();
          },
          error: (err) => {
            this.errorMsg = err.error?.message || 'Create failed';
          }
        });

    }
  }

  deleteStudent(id: number) {

    if (!confirm('Are you sure you want to delete this student?')) return;

    this.studentService.delete(id)
      .subscribe({
        next: () => {
          this.successMsg = 'Student deleted successfully';
          this.loadAll();
        },
        error: (err) => {
          this.errorMsg = err.error?.message || 'Delete failed';
        }
      });
  }

  afterSave() {
    this.showForm = false;
    this.loadAll();
  }

  cancel() {
    this.showForm = false;
  }
}