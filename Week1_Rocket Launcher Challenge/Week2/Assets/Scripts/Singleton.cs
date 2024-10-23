using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // get instance of singleton
            // [구현 사항 1]
            // Instance 프로퍼티의 get 부분을 완성하세요.
            // 이때 다양한 문제 상황에 대한 대응을 포함해야 함을 생각해두세요.
            // (미할당인 경우, 생성되지 않은 경우)
            if (instance == null)
            {
                // 인스턴스를 찾지 못했을 경우, 씬에서 해당 타입의 오브젝트를 찾음
                // 씬에 있는 모든 게임 오브젝트를 검색하여, 그 중 타입 T를 가진 첫 번째 컴포넌트를 반환
                instance = FindObjectOfType<T>();

                // 아직 생성되지 않은 경우, 새롭게 GameObject와 함께 생성
                if (instance == null)
                {
                    // 새 GameObject를 생성
                    // 오브젝트의 이름은 T(클래스명)과 같게 한다.
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    // 위 코드로 생성한 오브젝트에 T클래스 스크립트를 컴포넌트로 추가한다.
                    // 그리고 컴포넌트의 참조를 반환한다.
                    instance = singletonObject.AddComponent<T>();
                }
                return instance;
            }

            return instance;
        }
    }

    public virtual void Awake() // 싱글톤을 상속받는 클래스도 Awake를 재정의 할 수 있도록 virtual을 써주자
    {
        // make it as dontdestroyobject        

        if(instance == null)
        {
            // 현재 오브젝트(this)를 T 타입으로 캐스팅하고 그 값을 instance에 할당하여 싱글톤 인스턴스로 설정
            instance = this as T;

            // 루트 게임 오브젝트에 대해 DontDestroyOnLoad 적용
            // this.transform.root.gameObject는 현재 오브젝트의 루트 게임 오브젝트
            // 이걸 사용하면 만약 현재 오브젝트가 다른 오브젝트의 자식이라면,
            // 그 부모 게임 오브젝트까지도 DontDestroyOnLoad로 설정됩니다. 이로써 전체 계층 구조가 유지된다.
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            // 근데 만약 싱글톤 인스턴스가 이미 존재한다면 새로 생성된 오브젝트는 필요 없기 때문에 파괴한다.
            Destroy(this.gameObject);
        }
    }
}
