import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { z } from 'zod';

interface Student {
  studentId: string;
  studName: string;
  mobileNo: string;
  email: string;
  city: string;
  state: string;
  pincode: string;
  addressLine1: string;
  addressLine2: string;
}

const studentSchema = z.object({
  studName: z.string().min(2, { message: "Name is too short" }),
  mobileNo: z.string().length(10, { message: "Mobile number must be 10 digits" }).regex(/^\d+$/, { message: "Mobile must contain only digits" }),
  email: z.string().email({ message: "Invalid email address" }),
  city: z.string().optional(),
  state: z.string().optional(),
  pincode: z.string().optional(),
  addressLine1: z.string().optional(),
  addressLine2: z.string().optional()
});

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  students = signal<Student[]>([]);
  formData = signal<Student>(this.getEmptyForm());
  toastMessage = signal<string>('');
  toastType = signal<'success' | 'warning'>('success');
  showToast = signal<boolean>(false);
  apiUrl = 'http://localhost:5200/api/registration';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchStudents();
  }

  getEmptyForm(): Student {
    return {
      studentId: '',
      studName: '',
      mobileNo: '',
      email: '',
      city: '',
      state: '',
      pincode: '',
      addressLine1: '',
      addressLine2: ''
    };
  }

  fetchStudents() {
    this.http.get<Student[]>(this.apiUrl).subscribe({
      next: (data) => this.students.set(data),
      error: (err) => console.error(err)
    });
  }

  triggerToast(message: string, type: 'success' | 'warning' = 'success') {
    this.toastMessage.set(message);
    this.toastType.set(type);
    this.showToast.set(true);
    setTimeout(() => this.showToast.set(false), 3000);
  }

  onSubmit() {
    const currentData = this.formData();
    
    // Zod Validation
    const result = studentSchema.safeParse(currentData);
    if (!result.success) {
      const errorMsg = result.error.issues[0].message;
      this.triggerToast(errorMsg, 'warning');
      return;
    }

    const isUpdate = currentData.studentId !== '';
    if (isUpdate) {
      this.http.put(`${this.apiUrl}/${currentData.studentId}`, currentData).subscribe({
        next: () => {
          this.fetchStudents();
          this.handleClear();
          this.triggerToast('Student updated successfully!', 'success');
        },
        error: (err) => console.error(err)
      });
    } else {
      this.http.post(this.apiUrl, currentData).subscribe({
        next: () => {
          this.fetchStudents();
          this.handleClear();
          this.triggerToast('Student registered successfully!', 'success');
        },
        error: (err) => console.error(err)
      });
    }
  }

  handleEdit(student: Student) {
    this.formData.set({ ...student });
  }

  handleClear() {
    this.formData.set(this.getEmptyForm());
  }

  handleDelete(id: string) {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe({
      next: () => {
        this.fetchStudents();
        this.triggerToast('Student deleted successfully!', 'success');
      },
      error: (err) => console.error(err)
    });
  }
}
