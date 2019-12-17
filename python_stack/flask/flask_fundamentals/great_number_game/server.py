from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'secret af'

@app.route('/')
def index():
  if 'message' not in session:
    session['message'] = ''
  if 'number' not in session:
    session['number'] = random.randint(1,100)
  if 'count' not in session:
    session['count'] = 0
  if 'color' not in session:
    session['color'] = ''
  return render_template('index.html')

@app.route('/guess', methods=['post'])
def guess():
  guess = int(request.form['number'])
  session['count'] = session['count'] + 1
  if guess > session['number']:
    session['message'] = 'Too high'
    session['color'] = 'red'
  if guess < session['number']:
    session['message'] = 'Too low'
    session['color'] = 'red'
  elif guess == session['number']:
    session['message'] = 'Correct!'
    session['color'] = 'green'
  return redirect('/')

@app.route('/reset')
def reset():
  session['count'] = 0
  session.pop('number')
  session.pop('message')
  return redirect('/')


if __name__ == "__main__":
  app.run(debug=True)